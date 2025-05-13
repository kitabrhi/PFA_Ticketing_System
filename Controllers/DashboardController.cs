using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Ticketing_System.Models;
using Ticketing_System.Service_Layer.Interfaces;

namespace Ticketing_System.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context; // ✅ Ajout du champ manquant

        public DashboardController(
            ITicketService ticketService,
            UserManager<User> userManager,
            ApplicationDbContext context // ✅ Injection de ApplicationDbContext
        )
        {
            _ticketService = ticketService;
            _userManager = userManager;
            _context = context; // ✅ Affectation
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> TeamMembers()
        {
            var members = await _context.TeamMembers
                .Include(tm => tm.User)
                .Include(tm => tm.Team)
                .ToListAsync();

            return View("TeamMembers", members); // => /Views/Dashboard/TeamMembers.cshtml
        }

        [Authorize(Roles = "User")]
public async Task<IActionResult> MyReports()
{
    var userId = _userManager.GetUserId(User);
    var myTickets = await _ticketService.GetTicketsByUserIdAsync(userId);

    var groupedByStatus = myTickets
        .GroupBy(t => t.Status)
        .Select(g => new { Status = g.Key, Count = g.Count() })
        .ToList();

    var groupedByPriority = myTickets
        .GroupBy(t => t.Priority)
        .Select(g => new { Priority = g.Key, Count = g.Count() })
        .ToList();

    var groupedByCategory = myTickets
        .GroupBy(t => t.Category)
        .Select(g => new { Category = g.Key, Count = g.Count() })
        .ToList();

    ViewBag.ByStatus = groupedByStatus;
    ViewBag.ByPriority = groupedByPriority;
    ViewBag.ByCategory = groupedByCategory;

    return View("MyReports");
}


        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var myTickets = (await _ticketService.GetTicketsByUserIdAsync(userId)).ToList();

            var dist = await _ticketService.GetTicketStatusDistributionAsync();

            var vm = new DashboardViewModel
            {
                TotalTickets = myTickets.Count,
                NewTickets = dist.TryGetValue(TicketStatus.New, out var n) ? n : 0,
                InProgressTickets = dist.TryGetValue(TicketStatus.InProgress, out var ip) ? ip : 0,
                ResolvedTickets = dist.TryGetValue(TicketStatus.Resolved, out var r) ? r : 0,
                ClosedTickets = dist.TryGetValue(TicketStatus.Closed, out var c) ? c : 0,
                StatusDistribution = dist,
                RecentTickets = myTickets.OrderByDescending(t => t.CreatedDate).Take(5)
            };

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Tickets()
        {
            var userId = _userManager.GetUserId(User);
            var tickets = await _ticketService.GetTicketsByUserIdAsync(userId);

            return View(tickets);
        }
    }
}
