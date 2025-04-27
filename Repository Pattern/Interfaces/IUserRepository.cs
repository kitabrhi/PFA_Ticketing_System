using Ticketing_System.Models;
using System.Linq; // <= très important

namespace Ticketing_System.Repository_Pattern.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByIdAsync(string userId);
        Task<IEnumerable<User>> GetUsersByRoleAsync(string roleName);
        Task<bool> UpdateUserInfoAsync(User user);
        Task<bool> DeactivateUserAsync(string userId);
        Task<IEnumerable<User>> SearchUsersAsync(string searchTerm);
        Task<bool> IsEmailUniqueAsync(string email, string excludeUserId = null);

        // ✅ Ajoute cette ligne :
        IQueryable<User> Query();
    }
}
