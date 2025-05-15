using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Ticketing_System.Models;
using Ticketing_System.Service_Layer.Interfaces;

namespace Ticketing_System.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DiagnosticController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IAssignmentRuleService _assignmentRuleService;
        private readonly ITicketService _ticketService;

        public DiagnosticController(
            ApplicationDbContext context,
            UserManager<User> userManager,
            IAssignmentRuleService assignmentRuleService,
            ITicketService ticketService)
        {
            _context = context;
            _userManager = userManager;
            _assignmentRuleService = assignmentRuleService;
            _ticketService = ticketService;
        }

        public async Task<IActionResult> Index()
        {
            // Compter les tickets par statut
            var ticketsByStatus = await _context.Tickets
                .GroupBy(t => t.Status)
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .ToListAsync();

            // Compter les tickets par équipe
            var ticketsByTeam = await _context.Tickets
                .Where(t => t.AssignedToTeamID.HasValue)
                .GroupBy(t => t.AssignedToTeamID)
                .Select(g => new { TeamID = g.Key, Count = g.Count() })
                .ToListAsync();

            // Joindre les noms d'équipe
            var teamsInfo = new List<object>();
            foreach (var item in ticketsByTeam)
            {
                var team = await _context.SupportTeams.FindAsync(item.TeamID);
                teamsInfo.Add(new
                {
                    TeamID = item.TeamID,
                    TeamName = team?.TeamName ?? "Équipe inconnue",
                    Count = item.Count
                });
            }

            // Compter les tickets par agent
            var ticketsByAgent = await _context.Tickets
                .Where(t => !string.IsNullOrEmpty(t.AssignedToUserId))
                .GroupBy(t => t.AssignedToUserId)
                .Select(g => new { UserID = g.Key, Count = g.Count() })
                .ToListAsync();

            // Joindre les noms d'utilisateur
            var agentsInfo = new List<object>();
            foreach (var item in ticketsByAgent)
            {
                var user = await _userManager.FindByIdAsync(item.UserID);
                agentsInfo.Add(new
                {
                    UserID = item.UserID,
                    UserName = user?.UserName ?? "Utilisateur inconnu",
                    FullName = (user?.FirstName + " " + user?.LastName) ?? "Nom inconnu",
                    Count = item.Count
                });
            }

            // Compter les tickets non assignés 
            var unassignedTickets = await _context.Tickets
                .Where(t => string.IsNullOrEmpty(t.AssignedToUserId))
                .ToListAsync();

            // Obtenir les règles d'assignation
            var rules = await _assignmentRuleService.GetAllRulesAsync();

            // Préparer les informations des règles
            var rulesInfo = rules.Select(r => new
            {
                RuleID = r.RuleID,
                RuleName = r.RuleName,
                Category = r.Category?.ToString() ?? "Toutes",
                Priority = r.Priority?.ToString() ?? "Toutes",
                AssignToUserID = r.AssignToUserID,
                AssignToTeamID = r.AssignToTeamID,
                IsActive = r.IsActive,
                Order = r.RuleOrder
            }).ToList();

            // Support agents disponibles
            var supportAgents = await _userManager.GetUsersInRoleAsync("SupportAgent");
            var agentsData = supportAgents.Select(a => new
            {
                UserID = a.Id,
                UserName = a.UserName,
                FullName = a.FirstName + " " + a.LastName,
                Email = a.Email
            }).ToList();

            // Préparer le modèle
            ViewBag.TicketsByStatus = ticketsByStatus;
            ViewBag.TeamInfo = teamsInfo;
            ViewBag.AgentInfo = agentsInfo;
            ViewBag.UnassignedTickets = unassignedTickets;
            ViewBag.Rules = rulesInfo;
            ViewBag.SupportAgents = agentsData;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AssignAllUnassignedTickets()
        {
            var unassignedTickets = await _context.Tickets
                .Where(t => string.IsNullOrEmpty(t.AssignedToUserId))
                .ToListAsync();

            int successCount = 0;
            int errorCount = 0;

            foreach (var ticket in unassignedTickets)
            {
                try
                {
                    await _assignmentRuleService.AssignTicketToLeastBusyAgentAsync(ticket.TicketID);
                    successCount++;
                }
                catch (Exception)
                {
                    errorCount++;
                }
            }

            TempData["SuccessMessage"] = $"{successCount} tickets ont été assignés avec succès, {errorCount} tickets ont échoué.";

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RunDiagnostics()
        {
            try
            {
                var diagnosticInfo = new
                {
                    SupportAgentsCount = (await _userManager.GetUsersInRoleAsync("SupportAgent")).Count,
                    RulesCount = (await _assignmentRuleService.GetAllRulesAsync()).Count(),
                    UnassignedTickets = await _context.Tickets.CountAsync(t => string.IsNullOrEmpty(t.AssignedToUserId)),
                    TotalTickets = await _context.Tickets.CountAsync(),
                    TeamsCount = await _context.SupportTeams.CountAsync(),
                    TeamMembersCount = await _context.TeamMembers.CountAsync()
                };

                return Json(new { Success = true, Data = diagnosticInfo });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Error = ex.Message });
            }
        }
    }
}