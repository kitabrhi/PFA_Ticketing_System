using Ticketing_System.Models;
using Ticketing_System.Service_Layer.Interfaces;
using Ticketing_System.Repository.Interfaces;

namespace Ticketing_System.Service_Layer
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repository;
        private readonly ApplicationDbContext _context;


        public NotificationService(INotificationRepository repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }


        public async Task<List<Notification>> GetUserNotificationsAsync(string userId)
        {
            return await _repository.GetByUserIdAsync(userId);
        }

        public async Task MarkAsReadAsync(int notificationId)
        {
            var notification = await _repository.GetByIdAsync(notificationId);
            if (notification != null)
            {
                notification.IsRead = true;
                await _repository.SaveChangesAsync();
            }
        }
        public async Task CreateNotificationAsync(string userId, string title, string message)
{
    var notification = new Notification
    {
        UserId = userId,
        Title = title,
        Message = message,
        IsRead = false,
        DateSent = DateTime.Now
    };

    _context.Notifications.Add(notification);
    await _context.SaveChangesAsync();
}
    }


}