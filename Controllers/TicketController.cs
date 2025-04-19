using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
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

        public TicketController(
            ITicketService ticketService,
            ITicketCommentService commentService,
            ITicketHistoryService historyService,
            IAttachmentService attachmentService,
            UserManager<User> userManager)
        {
            _ticketService = ticketService;
            _commentService = commentService;
            _historyService = historyService;
            _attachmentService = attachmentService;
            _userManager = userManager;
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

                // Récupérer les commentaires, l'historique et les pièces jointes
                ViewBag.Comments = await _commentService.GetCommentsByTicketIdAsync(id);
                ViewBag.History = await _historyService.GetHistoryByTicketIdAsync(id);
                ViewBag.Attachments = await _attachmentService.GetAttachmentsByTicketIdAsync(id);

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

        // POST: Ticket/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Définir l'utilisateur actuel comme créateur
                    ticket.CreatedByUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    await _ticketService.CreateTicketAsync(ticket);
                    TempData["SuccessMessage"] = "Ticket created successfully!";
                    return RedirectToAction(nameof(MyTickets));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Unable to create ticket: {ex.Message}");
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

                // Si c'est un admin ou un agent, préparer la liste des agents
                if (User.IsInRole("Admin") || User.IsInRole("SupportAgent"))
                {
                    ViewBag.Agents = await _userManager.GetUsersInRoleAsync("SupportAgent");
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
            {
                return BadRequest();
            }

            // Vérifier si l'utilisateur est autorisé à modifier ce ticket
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

                if (ModelState.IsValid)
                {
                    try
                    {
                        await _ticketService.UpdateTicketAsync(ticket);
                        TempData["SuccessMessage"] = "Ticket updated successfully!";
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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

                var ticket = await _ticketService.GetTicketByIdAsync(id);
                return View(ticket);
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

            ViewBag.StatusDistribution = statusDistribution;
            ViewBag.PriorityDistribution = priorityDistribution;
            ViewBag.RecentTickets = recentTickets;

            return View();
        }
    }
}