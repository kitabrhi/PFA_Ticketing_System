using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using Ticketing_System.Models;
using System.Threading.Tasks;
using Ticketing_System.Service_Layer.Interfaces;

namespace Ticketing_System.Controllers
{
    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        private readonly ITicketService _ticketService;

        public UserController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // GET: /User/Dashboard
        // GET: /User/Dashboard
public async Task<IActionResult> Dashboard()
{
    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
    if (string.IsNullOrEmpty(userId))
        return Unauthorized();

    var myTickets = await _ticketService.GetTicketsByUserIdAsync(userId);

    ViewBag.TotalTickets = myTickets.Count();
    ViewBag.TicketsResolved = myTickets.Count(t => t.Status == TicketStatus.Resolved);
    ViewBag.TicketsOpen = myTickets.Count(t =>
        t.Status == TicketStatus.Open ||
        t.Status == TicketStatus.New);

    // ✅ Données dynamiques pour "Tickets by Category"
    var categoryGroups = myTickets
        .GroupBy(t => t.Category)
        .Select(g => new
        {
            Category = g.Key.ToString(),
            Count = g.Count()
        })
        .ToList();

    ViewBag.CategoryLabels = categoryGroups.Select(c => c.Category).ToList();
    ViewBag.CategoryValues = categoryGroups.Select(c => c.Count).ToList();

    return View(myTickets); // Crée ou modifie Views/User/Dashboard.cshtml
}


        // GET: /User/MyTickets
        public async Task<IActionResult> MyTickets()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var myTickets = await _ticketService.GetTicketsByUserIdAsync(userId);
            return View(myTickets); // Crée : Views/User/MyTickets.cshtml
        }

        // GET: /User/Profile
        public IActionResult Profile()
        {
            return View(); // Crée : Views/User/Profile.cshtml
        }

        // Redirection par défaut
        public IActionResult Index()
        {
            return RedirectToAction("Dashboard");
        }
    }
}
