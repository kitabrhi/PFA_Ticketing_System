using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ticketing_System.Models;
using Ticketing_System.Service_Layer;

namespace Ticketing_System.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsApiController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsApiController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // GET: api/Notifications/User/5
        [HttpGet("User/{userId}")]
        public async Task<ActionResult<IEnumerable<Notification>>> GetNotifications(string userId)
        {
            var notifications = await _notificationService.GetUserNotificationsAsync(userId);
            return Ok(notifications);
        }

        // PATCH: api/Notifications/5/MarkAsRead
        [HttpPatch("{id}/MarkAsRead")]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            try
            {
                await _notificationService.MarkAsReadAsync(id);
                return Ok(new { message = "Notification marked as read" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // POST: api/Notifications
        [HttpPost]
        public async Task<IActionResult> CreateNotification(string userId, string title, string message)
        {
            try
            {
                await _notificationService.CreateNotificationAsync(
                    userId, 
                    title, 
                    message);
                
                return StatusCode(201, new { message = "Notification created successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}