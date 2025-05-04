using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ticketing_System.Models;

namespace Ticketing_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

           public IActionResult About()
    {
        return View();
    }   

       // GET: Home/FAQ
        [HttpGet]
        public IActionResult FAQ()
        {
            return View();  // This should return the FAQ.cshtml view
        }

        // GET: Home/Contact
        [HttpGet]
        public IActionResult Contact()
        {
            return View(); // This will return /Views/Home/Contact.cshtml
        }

        // POST: Home/SubmitContactForm
        [HttpPost]
        public IActionResult SubmitContactForm(string name, string email, string message)
        {
            // Process the form here, e.g., send an email, save to the database, etc.
            
            // Optionally, you can add TempData to show a success message
            TempData["SuccessMessage"] = "Your message has been sent successfully!";
            return RedirectToAction("Contact");
        }

        [Authorize] // Pour s'assurer que seuls les utilisateurs connect�s puissent y acc�der
        public IActionResult Accueil()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
