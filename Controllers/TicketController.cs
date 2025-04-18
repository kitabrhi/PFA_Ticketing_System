using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Ticketing_System.Models;

namespace Ticketing_System.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly UserManager<User> _userManager;

        public TicketController(ITicketService ticketService, UserManager<User> userManager)
        {
            _ticketService = ticketService;
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
            ViewData["Categories"] = Enum.GetValues(typeof(TicketCategory))
                .Cast<TicketCategory>()
                .Select(c => new SelectListItem
                {
                    Value = c.ToString(),
                    Text = c.ToString()
                }).ToList();

            ViewData["Priorities"] = Enum.GetValues(typeof(TicketPriority))
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
                    return RedirectToAction(nameof(MyTickets));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Unable to create ticket: {ex.Message}");
                }
            }

            // En cas d'erreur, recréer les listes déroulantes
            ViewData["Categories"] = Enum.GetValues(typeof(TicketCategory))
                .Cast<TicketCategory>()
                .Select(c => new SelectListItem
                {
                    Value = c.ToString(),
                    Text = c.ToString()
                }).ToList();

            ViewData["Priorities"] = Enum.GetValues(typeof(TicketPriority))
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
                ViewData["Categories"] = Enum.GetValues(typeof(TicketCategory))
                    .Cast<TicketCategory>()
                    .Select(c => new SelectListItem
                    {
                        Value = c.ToString(),
                        Text = c.ToString(),
                        Selected = c.Equals(ticket.Category)
                    }).ToList();

                ViewData["Priorities"] = Enum.GetValues(typeof(TicketPriority))
                    .Cast<TicketPriority>()
                    .Select(p => new SelectListItem
                    {
                        Value = p.ToString(),
                        Text = p.ToString(),
                        Selected = p.Equals(ticket.Priority)
                    }).ToList();

                ViewData["Statuses"] = Enum.GetValues(typeof(TicketStatus))
                    .Cast<TicketStatus>()
                    .Select(s => new SelectListItem
                    {
                        Value = s.ToString(),
                        Text = s.ToString(),
                        Selected = s.Equals(ticket.Status)
                    }).ToList();

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
                ViewData["Categories"] = Enum.GetValues(typeof(TicketCategory))
                    .Cast<TicketCategory>()
                    .Select(c => new SelectListItem
                    {
                        Value = c.ToString(),
                        Text = c.ToString(),
                        Selected = c.Equals(ticket.Category)
                    }).ToList();

                ViewData["Priorities"] = Enum.GetValues(typeof(TicketPriority))
                    .Cast<TicketPriority>()
                    .Select(p => new SelectListItem
                    {
                        Value = p.ToString(),
                        Text = p.ToString(),
                        Selected = p.Equals(ticket.Priority)
                    }).ToList();

                ViewData["Statuses"] = Enum.GetValues(typeof(TicketStatus))
                    .Cast<TicketStatus>()
                    .Select(s => new SelectListItem
                    {
                        Value = s.ToString(),
                        Text = s.ToString(),
                        Selected = s.Equals(ticket.Status)
                    }).ToList();

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
                    return RedirectToAction(nameof(Index));
                }
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
    }
}