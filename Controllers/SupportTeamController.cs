using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketing_System.Models;
using Ticketing_System.Service_Layer;
using Ticketing_System.Service_Layer.Interfaces;

namespace Ticketing_System.Controllers
{
    [Authorize(Roles = "Admin,SupportAgent")]
    public class SupportTeamController : Controller
    {
        private readonly ISupportTeamService _teamService;
        private readonly UserManager<User> _userManager;
        private readonly INotificationService _notificationService;
        private readonly ITicketService _ticketService;
        private readonly ApplicationDbContext _context;

        public SupportTeamController(
            ISupportTeamService teamService,
            UserManager<User> userManager,
            INotificationService notificationService,
            ITicketService ticketService,
            ApplicationDbContext context)
        {
            _teamService = teamService;
            _userManager = userManager;
            _notificationService = notificationService;
            _ticketService = ticketService;
            _context = context;
        }

        // GET: Liste des �quipes
        public async Task<IActionResult> Index()
        {
            var teams = await _teamService.GetAllAsync();
            return View(teams);
        }

        // GET: Formulaire de cr�ation
        public async Task<IActionResult> Create()
        {
            await LoadViewBagDataWithSupportAgentsOnly();
            return View();
        }
        // GET: SupportTeam/Details/5
        // GET: SupportTeam/Details/5
        public async Task<IActionResult> Details(int id)
        {
            // Au lieu de simplement r�cup�rer l'�quipe par son ID, nous allons faire une requ�te plus compl�te
            var team = await _context.SupportTeams
                .Include(t => t.Manager)
                .Include(t => t.TeamMembers)
                    .ThenInclude(tm => tm.User)
                .Include(t => t.AssignedTickets)
                    .ThenInclude(t => t.CreatedByUser)
                .FirstOrDefaultAsync(t => t.TeamID == id);

            if (team == null)
            {
                return NotFound();
            }

            // Obtenir tous les membres de l'�quipe avec leurs d�tails
            var members = team.TeamMembers?.Select(tm => tm.User).ToList() ?? new List<User>();

            // Obtenir tous les tickets assign�s � l'�quipe
            var tickets = team.AssignedTickets?.ToList() ?? new List<Ticket>();

            ViewBag.Members = members;
            ViewBag.Tickets = tickets;

            return View(team);
        }

        // POST: Cr�ation d'une �quipe
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupportTeam team)
        {
            var selectedMemberIds = Request.Form["TeamMembersIds"].ToList();
            var selectedTicketIds = Request.Form["AssignedTicketsIds"]
                .Where(id => !string.IsNullOrEmpty(id))
                .Select(int.Parse)
                .ToList();

            // Supprimer la validation automatique sur les propri�t�s de navigation
            ModelState.Remove("Manager");
            ModelState.Remove("TeamMembers");
            ModelState.Remove("AssignedTickets");

            // Validations personnalis�es
            if (string.IsNullOrEmpty(team.ManagerId))
                ModelState.AddModelError("ManagerId", "Le manager est obligatoire.");

            // V�rifier que les membres s�lectionn�s sont des SupportAgents
            bool allAreSupportAgents = true;
            foreach (var userId in selectedMemberIds)
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null || !await _userManager.IsInRoleAsync(user, "SupportAgent"))
                {
                    allAreSupportAgents = false;
                    break;
                }
            }

            if (!allAreSupportAgents)
            {
                ModelState.AddModelError("TeamMembers", "Tous les membres doivent avoir le role SupportAgent.");
            }

            // Si erreurs de validation
            if (!ModelState.IsValid)
            {
                await LoadViewBagDataWithSupportAgentsOnly(team.ManagerId, selectedMemberIds, selectedTicketIds);
                return View(team);
            }

            try
            {
                // Cr�ation de l'�quipe
                var createdTeam = await _teamService.CreateTeamAsync(team, selectedMemberIds);

                // R�cup�ration de l'utilisateur connect�
                var user = await _userManager.GetUserAsync(User);

                // Cr�ation d'une notification pour l'utilisateur
                await _notificationService.CreateNotificationAsync(
                    user.Id,
                    "Une Nouvelle équipe Crée",
                    $"L'équipe \"{createdTeam.TeamName}\" a été crée avec succés."
                );

                // Notifications pour les membres ajout�s
                foreach (var memberId in selectedMemberIds)
                {
                    await _notificationService.CreateNotificationAsync(
                        memberId,
                        "?? Ajout à une équipe",
                        $"Vous avez été ajouté à l'équipe \"{createdTeam.TeamName}\"."
                    );
                }

                TempData["SuccessMessage"] = "L'équipe crée avec succés.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Une erreur s'est produite lors de la création de l'équipe: " + ex.Message);
                await LoadViewBagDataWithSupportAgentsOnly(team.ManagerId, selectedMemberIds, selectedTicketIds);
                return View(team);
            }
        }

        // GET: Modifier une �quipe
        public async Task<IActionResult> Edit(int id)
        {
            var team = await _teamService.GetByIdAsync(id);
            if (team == null) return NotFound();

            // R�cup�rer les membres actuels de l'�quipe
            var currentMemberIds = team.TeamMembers?.Select(tm => tm.UserId).ToList() ?? new List<string>();

            // R�cup�rer les tickets actuellement assign�s
            var currentTicketIds = team.AssignedTickets?.Select(t => t.TicketID).ToList() ?? new List<int>();

            await LoadViewBagDataWithSupportAgentsOnly(team.ManagerId, currentMemberIds, currentTicketIds);
            return View(team);
        }

        // POST: Enregistrer les modifications
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SupportTeam team)
        {
            if (id != team.TeamID) return BadRequest();

            var selectedMemberIds = Request.Form["TeamMembersIds"].ToList();
            var selectedTicketIds = Request.Form["AssignedTicketsIds"]
                .Where(tid => !string.IsNullOrEmpty(tid))
                .Select(int.Parse)
                .ToList();

            ModelState.Remove("Manager");
            ModelState.Remove("TeamMembers");
            ModelState.Remove("AssignedTickets");

            // Validation du manager
            if (string.IsNullOrEmpty(team.ManagerId))
                ModelState.AddModelError("ManagerId", "Le manager est obligatoire.");

            // V�rifier que les membres s�lectionn�s sont des SupportAgents
            bool allAreSupportAgents = true;
            foreach (var userId in selectedMemberIds)
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null || !await _userManager.IsInRoleAsync(user, "SupportAgent"))
                {
                    allAreSupportAgents = false;
                    break;
                }
            }

            if (!allAreSupportAgents)
            {
                ModelState.AddModelError("TeamMembers", "Tous les membres doivent avoir le rôle SupportAgent.");
            }

            if (!ModelState.IsValid)
            {
                await LoadViewBagDataWithSupportAgentsOnly(team.ManagerId, selectedMemberIds, selectedTicketIds);
                return View(team);
            }

            try
            {
                // Charger l'�quipe existante
                var existingTeam = await _context.SupportTeams
                    .Include(t => t.TeamMembers)
                    .Include(t => t.AssignedTickets)
                    .FirstOrDefaultAsync(t => t.TeamID == team.TeamID);

                if (existingTeam == null) return NotFound();

                // Mettre � jour les infos de base
                existingTeam.TeamName = team.TeamName;
                existingTeam.Description = team.Description;
                existingTeam.ManagerId = team.ManagerId;

                // Obtenir les membres actuels pour identifier les changements
                var currentMemberIds = existingTeam.TeamMembers.Select(tm => tm.UserId).ToList();

                // Membres supprim�s
                var removedMemberIds = currentMemberIds.Except(selectedMemberIds).ToList();

                // Nouveaux membres
                var newMemberIds = selectedMemberIds.Except(currentMemberIds).ToList();

                // Supprimer les membres
                _context.TeamMembers.RemoveRange(existingTeam.TeamMembers.Where(tm =>
                    removedMemberIds.Contains(tm.UserId)));

                // Ajouter les nouveaux membres
                foreach (var userId in newMemberIds)
                {
                    existingTeam.TeamMembers.Add(new TeamMember
                    {
                        UserId = userId,
                        TeamID = existingTeam.TeamID,
                        JoinDate = DateTime.Now
                    });

                    // Notification pour les nouveaux membres
                    await _notificationService.CreateNotificationAsync(
                        userId,
                        "?? Ajout à une équipe",
                        $"Vous avez été ajouté à l'équipe \"{existingTeam.TeamName}\"."
                    );
                }

                // Mise � jour des tickets assign�s
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

                TempData["SuccessMessage"] = "? équipe mise à jour avec succés.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Une erreur s'est produite lors de la mise à jour: " + ex.Message);
                await LoadViewBagDataWithSupportAgentsOnly(team.ManagerId, selectedMemberIds, selectedTicketIds);
                return View(team);
            }
        }

        // GET: Supprimer une �quipe
        public async Task<IActionResult> Delete(int id)
        {
            var team = await _teamService.GetByIdAsync(id);
            if (team == null) return NotFound();
            return View(team);
        }

        // POST: Confirmer la suppression
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _teamService.DeleteAsync(id);
                TempData["SuccessMessage"] = "L'équipe supprimée avec succés.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "? Erreur lors de la suppression: " + ex.Message;
                return RedirectToAction("Delete", new { id });
            }
        }

        // M�thode utilitaire pour charger les donn�es des listes d�roulantes
        // Cette version garantit que seuls les SupportAgents peuvent �tre ajout�s
        private async Task LoadViewBagDataWithSupportAgentsOnly(
            string managerId = null,
            List<string> selectedMemberIds = null,
            List<int> selectedTicketIds = null)
        {
            // Obtenir tous les utilisateurs
            var allUsers = await _userManager.Users
                .Where(u => u.IsActive)  // Uniquement les utilisateurs actifs
                .ToListAsync();

            // Filtrer pour obtenir uniquement les utilisateurs avec le r�le SupportAgent
            var supportAgents = new List<User>();
            foreach (var user in allUsers)
            {
                if (await _userManager.IsInRoleAsync(user, "SupportAgent"))
                {
                    supportAgents.Add(user);
                }
            }

            // Pr�parer les listes pour les managers (admin ou support)
            var managers = new List<User>();
            foreach (var user in allUsers)
            {
                if (await _userManager.IsInRoleAsync(user, "Admin") ||
                    await _userManager.IsInRoleAsync(user, "SupportAgent"))
                {
                    managers.Add(user);
                }
            }

            // R�cup�rer les tickets non assign�s ou assign�s � cette �quipe
            var tickets = await _context.Tickets
                .Where(t => t.AssignedToTeamID == null || selectedTicketIds != null && selectedTicketIds.Contains(t.TicketID))
                .ToListAsync();

            // Configurer les listes d�roulantes
            ViewBag.Users = new SelectList(managers, "Id", "UserName", managerId);
            ViewBag.TeamMembers = new MultiSelectList(supportAgents, "Id", "UserName", selectedMemberIds);
            ViewBag.AssignedTickets = new MultiSelectList(tickets, "TicketID", "Title", selectedTicketIds);
        }
    }
}