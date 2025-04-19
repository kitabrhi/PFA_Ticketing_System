using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ticketing_System;
using Ticketing_System.Models;
using Ticketing_System.Service_Layer.Interfaces;

[Authorize(Roles = "Admin")]
public class SupportTeamController : Controller
{
    private readonly ISupportTeamService _service;
    private readonly UserManager<User> _userManager;
    private readonly ApplicationDbContext _context;

    public SupportTeamController(
        ISupportTeamService service,
        UserManager<User> userManager,
        ApplicationDbContext context)
    {
        _service = service;
        _userManager = userManager;
        _context = context;
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
    public async Task<IActionResult> Create(SupportTeam team)
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


        // 🔹 Étape 1 : ajouter les membres (relation manuelle)
        team.TeamMembers = selectedMemberIds.Select(userId => new TeamMember
        {
            UserId = userId,
            JoinDate = DateTime.Now
        }).ToList();

        // 🔹 Ajouter l’équipe
        await _service.AddAsync(team); // inclut SaveChangesAsync dans le repository
        Console.WriteLine("✅ TeamID généré : " + team.TeamID);

        // 🔹 Étape 2 : assigner les tickets maintenant que le TeamID est généré
        var ticketsToAssign = await _context.Tickets
            .Where(t => selectedTicketIds.Contains(t.TicketID))
            .ToListAsync();

        foreach (var ticket in ticketsToAssign)
        {
            ticket.AssignedToTeamID = team.TeamID;
        }

        await _context.SaveChangesAsync(); // appliquer la liaison des tickets

        return RedirectToAction(nameof(Index));
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
        var tickets = await _context.Tickets.ToListAsync();

        ViewBag.Users = new SelectList(users, "Id", "UserName", managerId);
        ViewBag.TeamMembers = new MultiSelectList(users, "Id", "UserName", selectedMembers);
        ViewBag.AssignedTickets = new MultiSelectList(tickets, "TicketID", "Title", selectedTickets);
    }

    
}
