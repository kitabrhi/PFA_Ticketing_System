using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ticketing_System.Models;
using Ticketing_System.Service_Layer;
using Ticketing_System.Service_Layer.Interfaces;

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

        // ✅ GET: /Notification
        // Liste toutes les notifications de l'utilisateur connecté
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var notifications = await _notificationService.GetUserNotificationsAsync(user.Id);
            return View(notifications);
        }

        // ✅ POST: /Notification/MarkAsRead/{id}
        public async Task<IActionResult> MarkAsRead(int id)
        {
            await _notificationService.MarkAsReadAsync(id);
            return RedirectToAction("Index");
        }

        // ✅ GET: /Notification/TestSend
        // Permet de tester l’envoi d’une notification à soi-même
        [HttpGet]
        public async Task<IActionResult> TestSend()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            await _notificationService.CreateNotificationAsync(
                user.Id,
                "🔔 Notification de Test",
                "Ceci est une notification envoyée pour test."
            );

            TempData["SuccessMessage"] = "Notification test envoyée avec succès !";
            return RedirectToAction("Index");
        }
    }
}
