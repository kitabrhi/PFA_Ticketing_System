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
    [Authorize(Roles = "Admin")]
    public class SupportTeamController : Controller
    {
        private readonly ISupportTeamService _teamService;
        private readonly ITeamMemberService _memberService;
        private readonly UserManager<User> _userManager;
        private readonly INotificationService _notificationService;
        private readonly ITicketService _ticketService;

        public SupportTeamController(
            ISupportTeamService teamService,
            ITeamMemberService memberService,
            UserManager<User> userManager,
            INotificationService notificationService,
            ITicketService ticketService)
        {
            _teamService = teamService;
            _memberService = memberService;
            _userManager = userManager;
            _notificationService = notificationService;
            _ticketService = ticketService;
        }

        // GET: SupportTeam
        public async Task<IActionResult> Index()
        {
            var teams = await _teamService.GetAllAsync();
            return View(teams);
        }

        // GET: SupportTeam/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var team = await _teamService.GetByIdAsync(id);
            if (team == null)
                return NotFound();

            ViewBag.Members = await _memberService.GetMembersByTeamIdAsync(id);
            ViewBag.TicketCount = await _teamService.GetTicketCountAsync(id);
            ViewBag.HasActiveAgents = await _teamService.HasActiveAgentsAsync(id);

            return View(team);
        }

        // GET: SupportTeam/Create
        public async Task<IActionResult> Create()
        {
            await LoadViewBagDataAsync();
            return View();
        }

        // POST: SupportTeam/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupportTeam team)
        {
            var selectedMemberIds = Request.Form["MemberIds"].ToList();

            // Validation
            ModelState.Remove("Manager");
            ModelState.Remove("TeamMembers");
            ModelState.Remove("AssignedTickets");

            if (string.IsNullOrEmpty(team.ManagerId))
                ModelState.AddModelError("ManagerId", "Manager is required");

            if (!ModelState.IsValid)
            {
                await LoadViewBagDataAsync(team.ManagerId, selectedMemberIds);
                return View(team);
            }

            try
            {
                await _teamService.CreateTeamAsync(team, selectedMemberIds);
                TempData["SuccessMessage"] = "Team created successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error creating team: {ex.Message}");
                await LoadViewBagDataAsync(team.ManagerId, selectedMemberIds);
                return View(team);
            }
        }

        // GET: SupportTeam/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var team = await _teamService.GetByIdAsync(id);
            if (team == null)
                return NotFound();

            var members = await _memberService.GetMembersByTeamIdAsync(id);
            var memberIds = members.Select(m => m.UserId).ToList();

            await LoadViewBagDataAsync(team.ManagerId, memberIds);
            return View(team);
        }

        // POST: SupportTeam/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SupportTeam team)
        {
            if (id != team.TeamID)
                return BadRequest();

            var selectedMemberIds = Request.Form["MemberIds"].ToList();

            // Validation
            ModelState.Remove("Manager");
            ModelState.Remove("TeamMembers");
            ModelState.Remove("AssignedTickets");

            if (string.IsNullOrEmpty(team.ManagerId))
                ModelState.AddModelError("ManagerId", "Manager is required");

            if (!ModelState.IsValid)
            {
                await LoadViewBagDataAsync(team.ManagerId, selectedMemberIds);
                return View(team);
            }

            try
            {
                await _teamService.UpdateTeamAsync(team, selectedMemberIds);
                TempData["SuccessMessage"] = "Team updated successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error updating team: {ex.Message}");
                await LoadViewBagDataAsync(team.ManagerId, selectedMemberIds);
                return View(team);
            }
        }

        // GET: SupportTeam/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var team = await _teamService.GetByIdAsync(id);
            if (team == null)
                return NotFound();

            ViewBag.Members = await _memberService.GetMembersByTeamIdAsync(id);
            ViewBag.TicketCount = await _teamService.GetTicketCountAsync(id);

            return View(team);
        }

        // POST: SupportTeam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _teamService.DeleteAsync(id);
                TempData["SuccessMessage"] = "Team deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting team: {ex.Message}";
                return RedirectToAction(nameof(Delete), new { id });
            }
        }

        // POST: SupportTeam/AssignManager/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignManager(int teamId, string managerId)
        {
            try
            {
                await _teamService.AssignManagerAsync(teamId, managerId);
                TempData["SuccessMessage"] = "Manager assigned successfully";
                return RedirectToAction(nameof(Details), new { id = teamId });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error assigning manager: {ex.Message}";
                return RedirectToAction(nameof(Details), new { id = teamId });
            }
        }

        // GET: SupportTeam/TeamTickets/5
        public async Task<IActionResult> TeamTickets(int id)
        {
            var team = await _teamService.GetByIdAsync(id);
            if (team == null)
                return NotFound();

            var tickets = await _ticketService.GetTicketsByAssignedTeamIdAsync(id);
            ViewBag.TeamName = team.TeamName;
            ViewBag.TeamId = id;

            return View(tickets);
        }

        // Helper methods
        private async Task LoadViewBagDataAsync(string selectedManagerId = null, List<string> selectedMemberIds = null)
        {
            // Get available managers (admin and support agents)
            var admins = await _userManager.GetUsersInRoleAsync("Admin");
            var supportAgents = await _userManager.GetUsersInRoleAsync("SupportAgent");
            var managers = admins.Union(supportAgents).OrderBy(u => u.LastName).ThenBy(u => u.FirstName);

            // Get potential members (all active users)
            var allUsers = await _userManager.Users.Where(u => u.IsActive).ToListAsync();

            ViewBag.Managers = new SelectList(managers, "Id", "Email", selectedManagerId);
            ViewBag.AllUsers = new MultiSelectList(allUsers, "Id", "Email", selectedMemberIds);
        }
    }
}