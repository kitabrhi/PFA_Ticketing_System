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
    [Authorize(Roles = "Admin")]
    public class EscalationRuleController : Controller
    {
        private readonly IEscalationRuleService _ruleService;
        private readonly ISupportTeamService _teamService;
        private readonly UserManager<User> _userManager;

        public EscalationRuleController(
            IEscalationRuleService ruleService,
            ISupportTeamService teamService,
            UserManager<User> userManager)
        {
            _ruleService = ruleService;
            _teamService = teamService;
            _userManager = userManager;
        }

        // GET: EscalationRule
        public async Task<IActionResult> Index()
        {
            var rules = await _ruleService.GetAllRulesAsync();
            return View(rules);
        }

        // GET: EscalationRule/Create
        public async Task<IActionResult> Create()
        {
            await PrepareViewBags();
            return View();
        }

        // POST: EscalationRule/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EscalationRule rule)
        {
            ModelState.Remove("EscalateToUser");
            ModelState.Remove("EscalateToTeam");

            if (ModelState.IsValid)
            {
                try
                {
                    await _ruleService.CreateRuleAsync(rule);
                    TempData["SuccessMessage"] = "Escalation rule created successfully!";
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

        // GET: EscalationRule/Edit/5
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

        // POST: EscalationRule/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EscalationRule rule)
        {
            if (id != rule.RuleID)
            {
                return BadRequest();
            }

            ModelState.Remove("EscalateToUser");
            ModelState.Remove("EscalateToTeam");

            if (ModelState.IsValid)
            {
                try
                {
                    await _ruleService.UpdateRuleAsync(rule);
                    TempData["SuccessMessage"] = "Escalation rule updated successfully!";
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

        // GET: EscalationRule/Delete/5
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

        // POST: EscalationRule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _ruleService.DeleteRuleAsync(id);
                TempData["SuccessMessage"] = "Escalation rule deleted successfully!";
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

        // GET: EscalationRule/TicketsNeedingEscalation
        public async Task<IActionResult> TicketsNeedingEscalation()
        {
            var tickets = await _ruleService.GetTicketsNeedingEscalationAsync();
            return View(tickets);
        }

        // POST: EscalationRule/EscalateTicket/5
        [HttpPost]
        public async Task<IActionResult> EscalateTicket(int ticketId)
        {
            try
            {
                var escalated = await _ruleService.CheckAndEscalateTicketAsync(ticketId);
                if (escalated)
                {
                    TempData["SuccessMessage"] = "Ticket escalated successfully!";
                }
                else
                {
                    TempData["InfoMessage"] = "Ticket does not meet escalation criteria.";
                }
                return RedirectToAction("Details", "Ticket", new { id = ticketId });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error escalating ticket: {ex.Message}";
                return RedirectToAction("Details", "Ticket", new { id = ticketId });
            }
        }

        private async Task PrepareViewBags()
        {
            // Priorités
            ViewBag.Priorities = Enum.GetValues(typeof(TicketPriority))
                .Cast<TicketPriority>()
                .Select(p => new SelectListItem
                {
                    Value = ((int)p).ToString(),
                    Text = p.ToString()
                }).ToList();

            // Statuts
            ViewBag.Statuses = Enum.GetValues(typeof(TicketStatus))
                .Cast<TicketStatus>()
                .Select(s => new SelectListItem
                {
                    Value = ((int)s).ToString(),
                    Text = s.ToString()
                }).ToList();

            // Utilisateurs de support
            var supportUsers = await _userManager.GetUsersInRoleAsync("SupportAgent");
            var admins = await _userManager.GetUsersInRoleAsync("Admin");
            var allSupportUsers = supportUsers.Union(admins).Distinct();

            ViewBag.SupportUsers = allSupportUsers.Select(u => new SelectListItem
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
