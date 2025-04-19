using Ticketing_System.Models;

namespace Ticketing_System.Repository.Interfaces
{
    public interface INotificationRepository
    {
        Task AddAsync(Notification notification);
        Task<List<Notification>> GetByUserIdAsync(string userId);
        Task<Notification?> GetByIdAsync(int id);
        Task SaveChangesAsync();
    }
}
