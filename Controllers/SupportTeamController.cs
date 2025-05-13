using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ticketing_System;
using Ticketing_System.Models;
using Ticketing_System.Service_Layer.Interfaces;
using Ticketing_System.Service_Layer;


[Authorize(Roles = "Admin")]
public class SupportTeamController : Controller
{
    private readonly ISupportTeamService _service;
    private readonly UserManager<User> _userManager;
    private readonly ApplicationDbContext _context;
    private INotificationService _notificationService;
    private ISupportTeamService _supportTeamService;

    public SupportTeamController(
        ISupportTeamService service,
        UserManager<User> userManager,
        INotificationService notificationService,
        ApplicationDbContext context)
    {
        _service = service;
        _userManager = userManager;
        _notificationService = notificationService;
        _context = context;
    }


    public IActionResult Dashboard()
        {
            return View();
        }


    // GET: Liste des équipes
    public async Task<IActionResult> Index()
    {
        var teams = await _service.GetAllAsync();
        return View(teams);
    }

    // GET: Formulaire de création
    public async Task<IActionResult> Create()
    {
        await RemplirViewBags();
        return View();
    }

    // POST: Création d’une équipe
[HttpPost]
[Authorize]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create(SupportTeam team)
{
    var selectedMemberIds = Request.Form["TeamMembersIds"].ToList();
    var selectedTicketIds = Request.Form["AssignedTicketsIds"].Select(int.Parse).ToList();

    // Supprimer la validation automatique sur les propriétés de navigation
    ModelState.Remove("Manager");
    ModelState.Remove("TeamMembers");
    ModelState.Remove("AssignedTickets");

    // Validations personnalisées
    if (string.IsNullOrEmpty(team.ManagerId))
        ModelState.AddModelError("ManagerId", "Le manager est obligatoire.");

    if (!selectedMemberIds.Any())
        ModelState.AddModelError("TeamMembers", "Veuillez sélectionner au moins un membre.");

    if (!selectedTicketIds.Any())
        ModelState.AddModelError("AssignedTickets", "Veuillez sélectionner au moins un ticket.");

    // Si erreurs de validation
    if (!ModelState.IsValid)
    {
        Console.WriteLine("❌ Formulaire invalide. Détails des erreurs :");
        foreach (var kvp in ModelState)
        {
            foreach (var error in kvp.Value.Errors)
            {
                Console.WriteLine($"Champ : {kvp.Key} - Erreur : {error.ErrorMessage}");
            }
        }

        await RemplirViewBags(team.ManagerId, selectedMemberIds, selectedTicketIds);
        return View(team);
    }

    try
    {
        // ✅ Création de l’équipe (via service)
        var createdTeam = await _service.CreateSupportTeamAsync(team, selectedMemberIds, selectedTicketIds);

        // ✅ Récupération de l'utilisateur connecté
        var user = await _userManager.GetUserAsync(User);

        // ✅ Création d'une notification pour l'utilisateur
        await _notificationService.CreateNotificationAsync(
            user.Id,
            "👥 Nouvelle Équipe Créée",
            $"L’équipe \"{createdTeam.TeamName}\" a été créée avec succès."
        );

        TempData["SuccessMessage"] = "✅ Équipe créée avec succès.";
        return RedirectToAction("Index");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Erreur lors de la création de l’équipe : {ex.Message}");
        ModelState.AddModelError("", "Une erreur s’est produite lors de la création de l’équipe.");
        await RemplirViewBags(team.ManagerId, selectedMemberIds, selectedTicketIds);
        return View(team);
    }
}



    //Edit

    [HttpPost]
    public async Task<IActionResult> Edit(SupportTeam team)
    {
        var selectedMemberIds = Request.Form["TeamMembersIds"].ToList();
        var selectedTicketIds = Request.Form["AssignedTicketsIds"].Select(int.Parse).ToList();

        ModelState.Remove("Manager");
        ModelState.Remove("TeamMembers");
        ModelState.Remove("AssignedTickets");

        if (string.IsNullOrEmpty(team.ManagerId))
            ModelState.AddModelError("ManagerId", "Le manager est obligatoire.");

        if (!selectedMemberIds.Any())
            ModelState.AddModelError("TeamMembers", "Veuillez sélectionner au moins un membre.");

        if (!selectedTicketIds.Any())
            ModelState.AddModelError("AssignedTickets", "Veuillez sélectionner au moins un ticket.");

        if (!ModelState.IsValid)
        {
            await RemplirViewBags(team.ManagerId, selectedMemberIds, selectedTicketIds);
            return View(team);
        }

        // Charger l’équipe existante
        var existingTeam = await _context.SupportTeams
            .Include(t => t.TeamMembers)
            .Include(t => t.AssignedTickets)
            .FirstOrDefaultAsync(t => t.TeamID == team.TeamID);

        if (existingTeam == null) return NotFound();

        // Mettre à jour les infos de base
        existingTeam.TeamName = team.TeamName;
        existingTeam.Description = team.Description;
        existingTeam.ManagerId = team.ManagerId;

        // ⚠️ MAJ des membres
        _context.TeamMembers.RemoveRange(existingTeam.TeamMembers);

        existingTeam.TeamMembers = selectedMemberIds.Select(userId => new TeamMember
        {
            UserId = userId,
            TeamID = existingTeam.TeamID,
            JoinDate = DateTime.Now
        }).ToList();

        // ⚠️ MAJ des tickets assignés
        var oldTickets = await _context.Tickets
            .Where(t => t.AssignedToTeamID == existingTeam.TeamID)
            .ToListAsync();

        foreach (var ticket in oldTickets)
            ticket.AssignedToTeamID = null;

        var newTickets = await _context.Tickets
            .Where(t => selectedTicketIds.Contains(t.TicketID))
            .ToListAsync();

        foreach (var ticket in newTickets)
            ticket.AssignedToTeamID = existingTeam.TeamID;

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
{
    var team = await _service.GetByIdAsync(id);
    if (team == null) return NotFound();

    var users = await _userManager.Users.ToListAsync();
    var tickets = await _context.Tickets.ToListAsync();

    ViewBag.Users = new SelectList(users, "Id", "UserName", team.ManagerId);
    ViewBag.TeamMembers = new MultiSelectList(users, "Id", "UserName", team.TeamMembers?.Select(tm => tm.UserId) ?? new List<string>());
    ViewBag.AssignedTickets = new MultiSelectList(tickets, "TicketID", "Title", team.AssignedTickets?.Select(t => t.TicketID) ?? new List<int>());

    return View(team);
}


        public async Task<IActionResult> Delete(int id)
{
    var team = await _service.GetByIdAsync(id);
    if (team == null) return NotFound();
    return View(team);
}


[HttpPost, ActionName("Delete")]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    await _service.DeleteAsync(id);
    return RedirectToAction(nameof(Index));
}



    // Méthode utilitaire pour charger les listes
    private async Task RemplirViewBags(string? managerId = null, List<string>? selectedMembers = null, List<int>? selectedTickets = null)
{
    var users = await _userManager.Users.ToListAsync();

    var supportAgents = new List<User>();
    var normalUsers = new List<User>();

    foreach (var user in users)
    {
        if (await _userManager.IsInRoleAsync(user, "SupportAgent"))
            supportAgents.Add(user);

        if (await _userManager.IsInRoleAsync(user, "User"))
            normalUsers.Add(user);
    }

    var tickets = await _context.Tickets.ToListAsync();

    ViewBag.Users = new SelectList(supportAgents, "Id", "UserName", managerId);
    ViewBag.TeamMembers = new MultiSelectList(normalUsers, "Id", "UserName", selectedMembers);
    ViewBag.AssignedTickets = new MultiSelectList(tickets, "TicketID", "Title", selectedTickets);
}


    
}
