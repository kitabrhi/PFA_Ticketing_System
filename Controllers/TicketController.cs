using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Ticketing_System.Models;
using Ticketing_System.Service_Layer.Interfaces;

namespace Ticketing_System.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly ITicketCommentService _commentService;
        private readonly ITicketHistoryService _historyService;
        private readonly IAttachmentService _attachmentService;
        private readonly UserManager<User> _userManager;
        private readonly IAssignmentRuleService _assignmentRuleService;
        private readonly IEscalationRuleService _escalationRuleService;
        private readonly ISupportTeamService _supportTeamService;

        public TicketController(
            ITicketService ticketService,
            ITicketCommentService commentService,
            ITicketHistoryService historyService,
            IAttachmentService attachmentService,
            UserManager<User> userManager,
            IAssignmentRuleService assignmentRuleService,
            IEscalationRuleService escalationRuleService)
        {
            _ticketService = ticketService;
            _commentService = commentService;
            _historyService = historyService;
            _attachmentService = attachmentService;
            _userManager = userManager;
            _assignmentRuleService = assignmentRuleService;
            _escalationRuleService = escalationRuleService;
        }

        // GET: Ticket
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var tickets = await _ticketService.GetAllTicketsAsync();
            return View(tickets);
        }

        // GET: Ticket/MyTickets
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> MyTickets()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tickets = await _ticketService.GetTicketsByUserIdAsync(userId);
            return View(tickets);
        }

        // GET: Ticket/AssignedTickets
        [HttpGet]
        [Authorize(Roles = "Admin,SupportAgent")]
        public async Task<IActionResult> AssignedTickets()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tickets = await _ticketService.GetTicketsByAssignedUserIdAsync(userId);
            return View(tickets);
        }

        // GET: Ticket/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var ticket = await _ticketService.GetTicketByIdAsync(id);
                var history = await _historyService.GetHistoryByTicketIdAsync(id);
                var comments = await _commentService.GetCommentsByTicketIdAsync(id);
                var attachments = await _attachmentService.GetAttachmentsByTicketIdAsync(id);

                // Récupérer tous les IDs d'utilisateurs uniques des historiques
                var historyUserIds = history.Select(h => h.ChangedByUserId).Distinct().ToList();

                // Charger les utilisateurs correspondants
                Dictionary<string, User> users = new Dictionary<string, User>();
                foreach (var userId in historyUserIds)
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        users[userId] = user;
                    }
                }

                ViewBag.History = history;
                ViewBag.HistoryUsers = users;
                ViewBag.Comments = comments;
                ViewBag.Attachments = attachments;

                // Check if the ticket is eligible for escalation
                if (User.IsInRole("Admin") || User.IsInRole("SupportAgent"))
                {
                    var ticketsNeedingEscalation = await _escalationRuleService.GetTicketsNeedingEscalationAsync();
                    ViewBag.NeedsEscalation = ticketsNeedingEscalation.Any(t => t.TicketID == id);
                }

                return View(ticket);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // GET: Ticket/Create
        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            // Préparer les listes déroulantes pour le formulaire
            ViewBag.Categories = Enum.GetValues(typeof(TicketCategory))
                .Cast<TicketCategory>()
                .Select(c => new SelectListItem
                {
                    Value = c.ToString(),
                    Text = c.ToString()
                }).ToList();

            ViewBag.Priorities = Enum.GetValues(typeof(TicketPriority))
                .Cast<TicketPriority>()
                .Select(p => new SelectListItem
                {
                    Value = p.ToString(),
                    Text = p.ToString()
                }).ToList();

            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ticket ticket)
        {
            // Injecter l'ID du user connecté
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ticket.CreatedByUserId = userId;
            ModelState.Remove(nameof(ticket.CreatedByUserId));

            // navigation suppression 
            ModelState.Remove("CreatedByUser");
            ModelState.Remove("AssignedToUser");
            ModelState.Remove("AssignedToTeam");
            ModelState.Remove("TicketComments");
            ModelState.Remove("TicketHistories");
            ModelState.Remove("TicketAttachments");

            if (ModelState.IsValid)
            {
                try
                {
                    // Create the ticket
                    var createdTicket = await _ticketService.CreateTicketAsync(ticket);

                    // Apply assignment rules automatically
                    await _assignmentRuleService.ApplyRuleToTicketAsync(createdTicket.TicketID);

                    TempData["SuccessMessage"] = "Ticket created successfully and automatically assigned according to rules!";
                    return RedirectToAction(nameof(MyTickets));
                }
                catch (Exception ex)
                {
                    var sqlError = ex.InnerException?.Message;
                    ModelState.AddModelError("",
                        $"Impossible de créer le ticket : {ex.Message} - Détail : {sqlError}");
                }
            }

            // En cas d'erreur, recréer les listes déroulantes
            ViewBag.Categories = Enum.GetValues(typeof(TicketCategory))
                .Cast<TicketCategory>()
                .Select(c => new SelectListItem
                {
                    Value = c.ToString(),
                    Text = c.ToString()
                }).ToList();

            ViewBag.Priorities = Enum.GetValues(typeof(TicketPriority))
                .Cast<TicketPriority>()
                .Select(p => new SelectListItem
                {
                    Value = p.ToString(),
                    Text = p.ToString()
                }).ToList();

            return View(ticket);
        }

        // GET: Ticket/Edit/5
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var ticket = await _ticketService.GetTicketByIdAsync(id);

                // Vérifier si l'utilisateur est autorisé à modifier ce ticket
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!User.IsInRole("Admin") && !User.IsInRole("SupportAgent") && ticket.CreatedByUserId != userId)
                {
                    return Forbid();
                }

                // Préparer les listes déroulantes
                ViewBag.Categories = Enum.GetValues(typeof(TicketCategory))
                    .Cast<TicketCategory>()
                    .Select(c => new SelectListItem
                    {
                        Value = c.ToString(),
                        Text = c.ToString(),
                        Selected = c.Equals(ticket.Category)
                    }).ToList();

                ViewBag.Priorities = Enum.GetValues(typeof(TicketPriority))
                    .Cast<TicketPriority>()
                    .Select(p => new SelectListItem
                    {
                        Value = p.ToString(),
                        Text = p.ToString(),
                        Selected = p.Equals(ticket.Priority)
                    }).ToList();

                ViewBag.Statuses = Enum.GetValues(typeof(TicketStatus))
                    .Cast<TicketStatus>()
                    .Select(s => new SelectListItem
                    {
                        Value = s.ToString(),
                        Text = s.ToString(),
                        Selected = s.Equals(ticket.Status)
                    }).ToList();

                // Si c'est un admin ou un agent, préparer la liste des agents et des équipes
                if (User.IsInRole("Admin") || User.IsInRole("SupportAgent"))
                {
                    ViewBag.Agents = await _userManager.GetUsersInRoleAsync("SupportAgent");
                    ViewBag.Teams = await _supportTeamService.GetAllAsync();
                }

                return View(ticket);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: Ticket/Edit/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ticket ticket)
        {
            if (id != ticket.TicketID)
                return BadRequest();

            try
            {
                var existingTicket = await _ticketService.GetTicketByIdAsync(id);
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (!User.IsInRole("Admin") && !User.IsInRole("SupportAgent") && existingTicket.CreatedByUserId != userId)
                {
                    return Forbid();
                }

                // Conserver certaines valeurs existantes qui ne doivent pas être modifiées
                ticket.CreatedByUserId = existingTicket.CreatedByUserId;
                ticket.CreatedDate = existingTicket.CreatedDate;

                ModelState.Remove("CreatedByUser");
                ModelState.Remove("AssignedToUser");
                ModelState.Remove("AssignedToTeam");
                ModelState.Remove("TicketComments");
                ModelState.Remove("TicketHistories");
                ModelState.Remove("TicketAttachments");

                if (ModelState.IsValid)
                {
                    try
                    {
                        // Only admins and support agents can modify the escalation status
                        if (!User.IsInRole("Admin") && !User.IsInRole("SupportAgent"))
                        {
                            ticket.IsEscalated = existingTicket.IsEscalated;
                        }

                        // Passer l'ID de l'utilisateur qui fait la modification
                        ticket.UpdatedByUserId = userId;
                        await _ticketService.UpdateTicketAsync(ticket);

                        // If ticket category or priority has changed, re-apply assignment rules
                        if (existingTicket.Category != ticket.Category || existingTicket.Priority != ticket.Priority)
                        {
                            await _assignmentRuleService.ApplyRuleToTicketAsync(ticket.TicketID);
                            TempData["SuccessMessage"] = "Ticket updated successfully and re-assigned based on rules!";
                        }
                        else
                        {
                            TempData["SuccessMessage"] = "Ticket updated successfully!";
                        }

                        return RedirectToAction(nameof(Details), new { id = ticket.TicketID });
                    }
                    catch (KeyNotFoundException)
                    {
                        return NotFound();
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", $"Unable to update ticket: {ex.Message}");
                    }
                }

                // Recréer les listes déroulantes en cas d'erreur
                ViewBag.Categories = Enum.GetValues(typeof(TicketCategory))
                    .Cast<TicketCategory>()
                    .Select(c => new SelectListItem
                    {
                        Value = c.ToString(),
                        Text = c.ToString(),
                        Selected = c.Equals(ticket.Category)
                    }).ToList();

                ViewBag.Priorities = Enum.GetValues(typeof(TicketPriority))
                    .Cast<TicketPriority>()
                    .Select(p => new SelectListItem
                    {
                        Value = p.ToString(),
                        Text = p.ToString(),
                        Selected = p.Equals(ticket.Priority)
                    }).ToList();

                ViewBag.Statuses = Enum.GetValues(typeof(TicketStatus))
                    .Cast<TicketStatus>()
                    .Select(s => new SelectListItem
                    {
                        Value = s.ToString(),
                        Text = s.ToString(),
                        Selected = s.Equals(ticket.Status)
                    }).ToList();

                if (User.IsInRole("Admin") || User.IsInRole("SupportAgent"))
                {
                    ViewBag.Agents = await _userManager.GetUsersInRoleAsync("SupportAgent");
                    ViewBag.Teams = await _supportTeamService.GetAllAsync();
                }

                return View(ticket);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // GET: Ticket/Delete/5
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var ticket = await _ticketService.GetTicketByIdAsync(id);
                return View(ticket);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _ticketService.DeleteTicketAsync(id);
                TempData["SuccessMessage"] = "Ticket deleted successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                // Retourner à la vue de suppression avec erreur
                try
                {
                    var ticket = await _ticketService.GetTicketByIdAsync(id);
                    ModelState.AddModelError("", $"Unable to delete ticket: {ex.Message}");
                    return View(ticket);
                }
                catch
                {
                    TempData["ErrorMessage"] = $"Error deleting ticket: {ex.Message}";
                    return RedirectToAction(nameof(Index));
                }
            }
        }

        // GET: Ticket/ChangeStatus/5?status=Resolved
        [HttpGet]
        [Authorize(Roles = "Admin,SupportAgent")]
        public async Task<IActionResult> ChangeStatus(int id, TicketStatus status)
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _ticketService.ChangeTicketStatusAsync(id, status, userId);

                // Check if ticket should be escalated after status change
                await _escalationRuleService.CheckAndEscalateTicketAsync(id);

                TempData["SuccessMessage"] = $"Ticket status changed to {status}";
                return RedirectToAction(nameof(Details), new { id });
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Details), new { id });
            }
        }

        // GET: Ticket/Assign/5
        [HttpGet]
        [Authorize(Roles = "Admin,SupportAgent")]
        public async Task<IActionResult> Assign(int id)
        {
            try
            {
                var ticket = await _ticketService.GetTicketByIdAsync(id);

                // Récupérer la liste des agents pour le dropdown
                ViewBag.Agents = await _userManager.GetUsersInRoleAsync("SupportAgent");
                ViewBag.Teams = await _supportTeamService.GetAllAsync();

                return View(ticket);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: Ticket/Assign/5
        [HttpPost]
        [Authorize(Roles = "Admin,SupportAgent")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Assign(int id, string assignedToUserId)
        {
            try
            {
                string updatedByUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _ticketService.AssignTicketAsync(id, assignedToUserId, updatedByUserId);
                TempData["SuccessMessage"] = "Ticket assigned successfully!";
                return RedirectToAction(nameof(Details), new { id });
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                // Récupérer à nouveau la liste des agents pour le dropdown
                ViewBag.Agents = await _userManager.GetUsersInRoleAsync("SupportAgent");
                ViewBag.Teams = await _supportTeamService.GetAllAsync();

                var ticket = await _ticketService.GetTicketByIdAsync(id);
                return View(ticket);
            }
        }

        // POST: Ticket/AssignTeam/5
        [HttpPost]
        [Authorize(Roles = "Admin,SupportAgent")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignTeam(int id, int teamId)
        {
            try
            {
                string updatedByUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _ticketService.AssignTicketToTeamAsync(id, teamId, updatedByUserId);
                TempData["SuccessMessage"] = "Ticket assigned to team successfully!";
                return RedirectToAction(nameof(Details), new { id });
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Details), new { id });
            }
        }

        // POST: Ticket/ApplyAssignmentRule/5
        [HttpPost]
        [Authorize(Roles = "Admin,SupportAgent")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApplyAssignmentRule(int id)
        {
            try
            {
                await _assignmentRuleService.ApplyRuleToTicketAsync(id);
                TempData["SuccessMessage"] = "Assignment rules applied successfully!";
                return RedirectToAction(nameof(Details), new { id });
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error applying assignment rules: {ex.Message}";
                return RedirectToAction(nameof(Details), new { id });
            }
        }

        // POST: Ticket/EscalateTicket/5
        [HttpPost]
        [Authorize(Roles = "Admin,SupportAgent")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EscalateTicket(int id)
        {
            try
            {
                var ticket = await _ticketService.GetTicketByIdAsync(id);
                var rules = await _escalationRuleService.GetAllRulesAsync();
                var rule = rules.FirstOrDefault(r =>
                    (r.Priority == null || r.Priority == ticket.Priority) &&
                    (r.Status == null || r.Status == ticket.Status));

                if (rule != null)
                {
                    await _escalationRuleService.EscalateTicketAsync(id, rule);
                    TempData["SuccessMessage"] = "Ticket escalated successfully!";
                }
                else
                {
                    TempData["WarningMessage"] = "No matching escalation rule found for this ticket.";
                }

                return RedirectToAction(nameof(Details), new { id });
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error escalating ticket: {ex.Message}";
                return RedirectToAction(nameof(Details), new { id });
            }
        }

        // GET: Ticket/Search
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        // POST: Ticket/Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                ModelState.AddModelError("", "Please enter a search term");
                return View();
            }

            var tickets = await _ticketService.SearchTicketsAsync(searchTerm);
            return View("SearchResults", tickets);
        }

        // GET: Ticket/FilterByStatus/Open
        [HttpGet]
        public async Task<IActionResult> FilterByStatus(TicketStatus status)
        {
            var tickets = await _ticketService.GetTicketsByStatusAsync(status);
            ViewData["CurrentFilter"] = $"Status: {status}";
            return View("Index", tickets);
        }

        // GET: Ticket/FilterByPriority/High
        [HttpGet]
        public async Task<IActionResult> FilterByPriority(TicketPriority priority)
        {
            var tickets = await _ticketService.GetTicketsByPriorityAsync(priority);
            ViewData["CurrentFilter"] = $"Priority: {priority}";
            return View("Index", tickets);
        }

        // GET: Ticket/FilterByCategory/HardwareIssue
        [HttpGet]
        public async Task<IActionResult> FilterByCategory(TicketCategory category)
        {
            var tickets = await _ticketService.GetTicketsByCategoryAsync(category);
            ViewData["CurrentFilter"] = $"Category: {category}";
            return View("Index", tickets);
        }

        // GET: Ticket/Dashboard
        [HttpGet]
        [Authorize(Roles = "Admin,SupportAgent")]
        public async Task<IActionResult> Dashboard()
        {
            // Récupérer les statistiques des tickets
            var statusDistribution = await _ticketService.GetTicketStatusDistributionAsync();
            var priorityDistribution = await _ticketService.GetTicketPriorityDistributionAsync();

            // Récupérer les tickets récents
            var recentTickets = (await _ticketService.GetAllTicketsAsync())
                .OrderByDescending(t => t.CreatedDate)
                .Take(10);

            // Récupérer les tickets nécessitant une escalade
            var ticketsNeedingEscalation = await _escalationRuleService.GetTicketsNeedingEscalationAsync();

            ViewBag.StatusDistribution = statusDistribution;
            ViewBag.PriorityDistribution = priorityDistribution;
            ViewBag.RecentTickets = recentTickets;
            ViewBag.TicketsNeedingEscalation = ticketsNeedingEscalation;

            return View();
        }
    }
}