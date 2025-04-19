using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Ticketing_System.Models;
using Ticketing_System.Service_Layer;

namespace Ticketing_System.Controllers
{
    [Authorize]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly UserManager<User> _userManager;

        public NotificationController(INotificationService notificationService, UserManager<User> userManager)
        {
            _notificationService = notificationService;
            _userManager = userManager;
        }

        // Affiche toutes les notifications de l'utilisateur connecté
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var notifications = await _notificationService.GetUserNotificationsAsync(user.Id);
            return View(notifications);
        }

        // Marque une notification comme lue
        public async Task<IActionResult> MarkAsRead(int id)
        {
            await _notificationService.MarkAsReadAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
public async Task<IActionResult> TestSend()
{
    var user = await _userManager.GetUserAsync(User);

    if (user == null)
        return Unauthorized();

    await _notificationService.CreateNotificationAsync(
        user.Id,
        "🔔 Test Notification",
        "Ceci est une notification de test depuis NotificationController."
    );

    TempData["Message"] = "Notification test envoyée !";
    return RedirectToAction("Index");
}
    }


    
}
