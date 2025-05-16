using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;
using Ticketing_System.Models;
using Ticketing_System.Service_Layer.Interfaces;

namespace Ticketing_System.Controllers
{
    [Authorize(Roles = "Admin,SupportAgent" )]
    public class AssignmentRuleController : Controller
    {
        private readonly IAssignmentRuleService _ruleService;
        private readonly ISupportTeamService _teamService;
        private readonly UserManager<User> _userManager;

        public AssignmentRuleController(
            IAssignmentRuleService ruleService,
            ISupportTeamService teamService,
            UserManager<User> userManager)
        {
            _ruleService = ruleService;
            _teamService = teamService;
            _userManager = userManager;
        }

        // GET: AssignmentRule
        public async Task<IActionResult> Index()
        {
            var rules = await _ruleService.GetAllRulesAsync();
            return View(rules);
        }

        // GET: AssignmentRule/Create
        public async Task<IActionResult> Create()
        {
            await PrepareViewBags();
            return View();
        }

        // POST: AssignmentRule/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AssignmentRule rule)
        {
            ModelState.Remove("AssignToTeam");
            ModelState.Remove("AssignToUser");

            if (ModelState.IsValid)
            {
                try
                {
                    await _ruleService.CreateRuleAsync(rule);
                    TempData["SuccessMessage"] = "Assignment rule created successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error creating rule: {ex.Message}");
                }
            }

            await PrepareViewBags();
            return View(rule);
        }

        // GET: AssignmentRule/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var rule = await _ruleService.GetRuleByIdAsync(id);
                await PrepareViewBags();
                return View(rule);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: AssignmentRule/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AssignmentRule rule)
        {
            if (id != rule.RuleID)
            {
                return BadRequest();
            }

            ModelState.Remove("AssignToTeam");
            ModelState.Remove("AssignToUser");

            if (ModelState.IsValid)
            {
                try
                {
                    await _ruleService.UpdateRuleAsync(rule);
                    TempData["SuccessMessage"] = "Assignment rule updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (KeyNotFoundException)
                {
                    return NotFound();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error updating rule: {ex.Message}");
                }
            }

            await PrepareViewBags();
            return View(rule);
        }

        // GET: AssignmentRule/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var rule = await _ruleService.GetRuleByIdAsync(id);
                return View(rule);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: AssignmentRule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _ruleService.DeleteRuleAsync(id);
                TempData["SuccessMessage"] = "Assignment rule deleted successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting rule: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: AssignmentRule/ApplyToTicket/5
        [HttpPost]
        public async Task<IActionResult> ApplyToTicket(int ticketId)
        {
            try
            {
                await _ruleService.ApplyRuleToTicketAsync(ticketId);
                TempData["SuccessMessage"] = "Assignment rule applied successfully!";
                return RedirectToAction("Details", "Ticket", new { id = ticketId });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error applying rule: {ex.Message}";
                return RedirectToAction("Details", "Ticket", new { id = ticketId });
            }
        }

        private async Task PrepareViewBags()
        {
            // Catégories
            ViewBag.Categories = Enum.GetValues(typeof(TicketCategory))
                .Cast<TicketCategory>()
                .Select(c => new SelectListItem
                {
                    Value = ((int)c).ToString(),
                    Text = c.ToString()
                }).ToList();

            // Priorités
            ViewBag.Priorities = Enum.GetValues(typeof(TicketPriority))
                .Cast<TicketPriority>()
                .Select(p => new SelectListItem
                {
                    Value = ((int)p).ToString(),
                    Text = p.ToString()
                }).ToList();

            // Agents de support
            var supportAgents = await _userManager.GetUsersInRoleAsync("SupportAgent");
            ViewBag.SupportAgents = supportAgents.Select(u => new SelectListItem
            {
                Value = u.Id,
                Text = $"{u.FirstName} {u.LastName}"
            }).ToList();

            // Équipes
            var teams = await _teamService.GetAllAsync();
            ViewBag.Teams = teams.Select(t => new SelectListItem
            {
                Value = t.TeamID.ToString(),
                Text = t.TeamName
            }).ToList();
        }
    }
}
