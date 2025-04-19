using Ticketing_System.Models;

namespace Ticketing_System.Service_Layer
{
    public interface INotificationService
    {
        Task CreateNotificationAsync(string userId, string title, string message);
        Task<List<Notification>> GetUserNotificationsAsync(string userId);
        Task MarkAsReadAsync(int notificationId);
    }
}
