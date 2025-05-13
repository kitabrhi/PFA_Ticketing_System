using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ticketing_System.Controllers
{
    [Authorize(Roles = "SupportAgent")]
public class SupportAgentController : Controller
{
    private readonly ApplicationDbContext _context;

    public SupportAgentController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Dashboard()
    {
        var statusData = _context.Tickets
            .GroupBy(t => t.Status)
            .Select(g => new { Status = g.Key, Count = g.Count() })
            .ToList();

        var trendData = _context.Tickets
            .Where(t => t.UpdatedDate >= DateTime.Now.AddDays(-7))
            .GroupBy(t => t.UpdatedDate.Date)
            .Select(g => new { Day = g.Key.ToString("ddd"), Count = g.Count() })
            .ToList();

        ViewBag.TicketsParStatut = statusData;
        ViewBag.TicketsParJour = trendData;

        return View();
    }
}

}
