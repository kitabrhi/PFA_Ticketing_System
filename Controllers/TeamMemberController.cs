using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ticketing_System.Models;
using Ticketing_System.Service_Layer.Interfaces;
using Ticketing_System.Service_Layer;

namespace Ticketing_System.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TeamMemberController : Controller
    {
        private readonly ITeamMemberService _service;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly INotificationService _notificationService;

        private readonly RoleManager<Role> _roleManager;

        public TeamMemberController(
            ITeamMemberService service,
            ApplicationDbContext context,
            UserManager<User> userManager,
            INotificationService notificationService,
            RoleManager<Role> roleManager)
        {
            _service = service;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _notificationService = notificationService;
        }

        // 🔹 Affiche la liste des membres
        public async Task<IActionResult> Index()
        {
            var members = await _service.GetAllAsync();
            return View(members);
        }

        // 🔹 Formulaire d’ajout
        public async Task<IActionResult> Create()
        {
            await LoadDropdowns();
            return View();
        }

        // 🔹 Soumission formulaire d’ajout
        [HttpPost]
public async Task<IActionResult> Create(TeamMember member)
{
    ModelState.Remove("Team");
    ModelState.Remove("User");

    if (!ModelState.IsValid)
    {
        await LoadDropdowns(member.TeamID, member.UserId);
        return View(member);
    }

    await _service.AddAsync(member);

    // 🔔 Créer une notification pour l’admin (ou celui qui est connecté)
    var user = await _userManager.GetUserAsync(User);
    var addedUser = await _userManager.FindByIdAsync(member.UserId);
    var team = await _context.SupportTeams.FindAsync(member.TeamID);

    if (user != null && addedUser != null && team != null)
    {
        await _notificationService.CreateNotificationAsync(
            user.Id,
            "👤 Nouveau Membre d’Équipe",
            $"L’utilisateur {addedUser.FirstName} {addedUser.LastName} a été ajouté à l’équipe \"{team.TeamName}\"."
        );
    }

    TempData["SuccessMessage"] = "✅ Membre ajouté et notification envoyée.";
    return RedirectToAction(nameof(Index));
}


    // GET: Confirmation de suppression d’un TeamMember
public async Task<IActionResult> Delete(int id)
{
    var member = await _service.GetByIdAsync(id);
    if (member == null) return NotFound();
    return View(member);
}

// POST: Suppression confirmée
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    var member = await _service.GetByIdAsync(id);
    if (member == null) return NotFound();

    await _service.DeleteAsync(id); // ⬅️ supprime le lien équipe-utilisateur, pas l'utilisateur complet

    return RedirectToAction(nameof(Index));
}


        // 🔹 Chargement des dropdowns
        private async Task LoadDropdowns(int? teamId = null, string? userId = null)
        {
            var supportAgents = await GetSupportAgentsAsync();
            ViewBag.Users = new SelectList(supportAgents, "Id", "UserName", userId);
            ViewBag.Teams = new SelectList(await _context.SupportTeams.ToListAsync(), "TeamID", "TeamName", teamId);
        }

        // 🔹 Récupère les utilisateurs ayant le rôle SupportAgent
        private async Task<List<User>> GetSupportAgentsAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var agents = new List<User>();

            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, "SupportAgent"))
                {
                    agents.Add(user);
                }
            }

            return agents;
        }

        // 🔹 Formulaire d’ajout d’un SupportAgent
        public IActionResult AddAgent()
        {
            return View();
        }

        // 🔹 Traitement d’ajout d’un SupportAgent
        [HttpPost]
        public async Task<IActionResult> AddAgent(IFormCollection form)
        {
            string firstName = form["FirstName"];
            string lastName = form["LastName"];
            string email = form["Email"];
            string password = form["Password"];

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError("", "Tous les champs sont obligatoires.");
                return View();
            }

            var user = new User
            {
                UserName = email,
                Email = email,
                FirstName = firstName,
                LastName = lastName
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "SupportAgent");
                TempData["Success"] = "✅ SupportAgent ajouté avec succès.";
                return RedirectToAction("AddAgent");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View();
        }
    }
}
