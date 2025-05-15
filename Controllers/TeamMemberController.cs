using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ticketing_System.Models;
using Ticketing_System.Service_Layer;
using Ticketing_System.Service_Layer.Interfaces;

namespace Ticketing_System.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TeamMemberController : Controller
    {
        private readonly ITeamMemberService _memberService;
        private readonly ISupportTeamService _teamService;
        private readonly UserManager<User> _userManager;
        private readonly INotificationService _notificationService;


        public TeamMemberController(
            ITeamMemberService memberService,
            ISupportTeamService teamService,
            UserManager<User> userManager,
            INotificationService notificationService)
        {
            _memberService = memberService;
            _teamService = teamService;
            _userManager = userManager;
            _notificationService = notificationService;
        }

        // GET: TeamMember
        public async Task<IActionResult> Index()
        {
            var members = await _memberService.GetAllAsync();
            return View(members);
        }

        // GET: TeamMember/Create
        public async Task<IActionResult> Create()
        {
            await LoadViewBagDataAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeamMember member)
        {
            ModelState.Remove("Team");
            ModelState.Remove("User");

            if (!ModelState.IsValid)
            {
                await LoadViewBagDataAsync(member.TeamID, member.UserId);
                return View(member);
            }

            // Vérifier si l'utilisateur est déjà membre de cette équipe
            var existingMember = await _memberService.GetMembersByTeamIdAsync(member.TeamID);
            var userAlreadyInTeam = existingMember.Any(tm => tm.UserId == member.UserId);

            if (userAlreadyInTeam)
            {
                ModelState.AddModelError("", "Cet utilisateur est déjà membre de cette équipe.");
                await LoadViewBagDataAsync(member.TeamID, member.UserId);
                return View(member);
            }

            // Vérifier que l'utilisateur est un SupportAgent
            var user = await _userManager.FindByIdAsync(member.UserId);
            if (user == null || !await _userManager.IsInRoleAsync(user, "SupportAgent"))
            {
                ModelState.AddModelError("UserId", "Seuls les agents de support peuvent être ajoutés aux équipes.");
                await LoadViewBagDataAsync(member.TeamID, member.UserId);
                return View(member);
            }

            // Ajouter le membre à l'équipe
            member.JoinDate = DateTime.Now;
            await _memberService.AddAsync(member);

            // Créer une notification
            var adminUser = await _userManager.GetUserAsync(User);
            var team = await _teamService.GetByIdAsync(member.TeamID);

            if (adminUser != null && user != null && team != null)
            {
                await _notificationService.CreateNotificationAsync(
                    adminUser.Id,
                    " Nouveau membre d'équipe",
                    $"L'utilisateur {user.FirstName} {user.LastName} a été ajouté à l'équipe \"{team.TeamName}\"."
                );

                // Notification pour l'utilisateur ajouté
                await _notificationService.CreateNotificationAsync(
                    user.Id,
                    " Ajout à une équipe",
                    $"Vous avez été ajouté à l'équipe de support \"{team.TeamName}\"."
                );
            }

            TempData["SuccessMessage"] = " Membre ajouté avec succès";
            return RedirectToAction(nameof(Index));
        }

        // GET: TeamMember/AddMemberToTeam/5
        [HttpGet]
        public async Task<IActionResult> AddMemberToTeam(int teamId)
        {
            var team = await _teamService.GetByIdAsync(teamId);
            if (team == null)
                return NotFound();

            ViewBag.Team = team;

            // Get users who are not already members of this team
            var users = _userManager.Users.Where(u => u.IsActive).ToList(); // Use synchronous method
            var teamMembers = await _memberService.GetMembersByTeamIdAsync(teamId);
            var teamMemberIds = teamMembers.Select(tm => tm.UserId).ToList();
            var availableUsers = users.Where(u => !teamMemberIds.Contains(u.Id)).ToList();

            ViewBag.Users = new SelectList(availableUsers, "Id", "Email");

            return View();
        }

        // POST: TeamMember/AddMemberToTeam
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMemberToTeam(int teamId, string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                TempData["ErrorMessage"] = "Please select a user";
                return RedirectToAction(nameof(AddMemberToTeam), new { teamId });
            }

            try
            {
                await _memberService.AddMemberToTeamAsync(userId, teamId);
                TempData["SuccessMessage"] = "Member added to team successfully";
                return RedirectToAction("Details", "SupportTeam", new { id = teamId });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error adding member to team: {ex.Message}";
                return RedirectToAction(nameof(AddMemberToTeam), new { teamId });
            }
        }

        // GET: TeamMember/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var member = await _memberService.GetByIdAsync(id);
            if (member == null)
                return NotFound();

            return View(member);
        }

        // POST: TeamMember/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var member = await _memberService.GetByIdAsync(id);
                if (member == null)
                    return NotFound();

                int teamId = member.TeamID;

                await _memberService.DeleteAsync(id);
                TempData["SuccessMessage"] = "Team member removed successfully";

                // Check if we should redirect back to the team's details page
                if (Request.Headers["Referer"].ToString().Contains($"SupportTeam/Details/{teamId}"))
                {
                    return RedirectToAction("Details", "SupportTeam", new { id = teamId });
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error removing team member: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: TeamMember/CreateAgent
        public async Task<IActionResult> CreateAgent()
        {
            var teams = await _teamService.GetAllAsync();
            ViewBag.Teams = new SelectList(teams, "TeamID", "TeamName");
            return View();
        }

        // POST: TeamMember/CreateAgent
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAgent(string firstName, string lastName, string email, string password, int teamId)

        {

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("", "All fields are required");
                var teams = await _teamService.GetAllAsync();
                ViewBag.Teams = new SelectList(teams, "TeamID", "TeamName", teamId);
                return View();
            }

            try
            {
                var user = await _memberService.CreateAgentAndAddToTeamAsync(firstName, lastName, email, password, teamId);
                TempData["SuccessMessage"] = $"Support agent {firstName} {lastName} created and added to team successfully";
                return RedirectToAction("Details", "SupportTeam", new { id = teamId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error creating support agent: {ex.Message}");
                var teams = await _teamService.GetAllAsync();
                ViewBag.Teams = new SelectList(teams, "TeamID", "TeamName", teamId);
                return View();
            }
        }

        // GET: TeamMember/TeamsByUser/userId
        public async Task<IActionResult> TeamsByUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound();

            var userTeams = await _memberService.GetTeamsByUserIdAsync(userId);

            ViewBag.User = user;
            return View(userTeams);
        }

        // GET: TeamMember/Teams
        [HttpGet]
        [Authorize(Roles = "Admin,SupportAgent")]
        public async Task<IActionResult> Teams()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            // Si l'utilisateur est un administrateur, afficher toutes les équipes
            if (User.IsInRole("Admin"))
            {
                var allTeams = await _teamService.GetAllAsync();
                return View(allTeams);
            }
            
            // Pour un agent, récupérer uniquement les équipes dont il est membre
            var teamMembers = await _memberService.GetTeamsByUserIdAsync(userId);
            
            // Convertir la liste de TeamMember en liste de SupportTeam
            var teams = teamMembers.Select(tm => tm.Team).Distinct().ToList();
            
            return View(teams);
        }

        // Private helper methods
        private async Task LoadViewBagDataAsync(int? teamId = null, string userId = null)
        {
            var teams = await _teamService.GetAllAsync();

            // Get users who can be added to teams (non-admin users)
            var users = _userManager.Users.Where(u => u.IsActive).ToList(); // Use synchronous method

            ViewBag.Teams = new SelectList(teams, "TeamID", "TeamName", teamId);
            ViewBag.Users = new SelectList(users, "Id", "Email", userId);
        }
    }
}