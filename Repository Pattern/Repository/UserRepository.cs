using Microsoft.EntityFrameworkCore;
using Ticketing_System.Models;
using Ticketing_System.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Ticketing_System.Repository_Pattern.Interfaces;

namespace Ticketing_System.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly UserManager<User> _userManager;

        public UserRepository(ApplicationDbContext context, UserManager<User> userManager) : base(context)
        {
            _userManager = userManager;
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<IEnumerable<User>> GetUsersByRoleAsync(string roleName)
        {
            var usersInRole = await _userManager.GetUsersInRoleAsync(roleName);
            return usersInRole;
        }

        public async Task<bool> UpdateUserInfoAsync(User user)
        {
            var existingUser = await GetUserByIdAsync(user.Id);
            if (existingUser == null) return false;

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.IsActive = user.IsActive;

            _dbSet.Update(existingUser);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeactivateUserAsync(string userId)
        {
            var user = await GetUserByIdAsync(userId);
            if (user == null) return false;

            user.IsActive = false;
            _dbSet.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>> SearchUsersAsync(string searchTerm)
        {
            return await _dbSet
                .Where(u => u.Email.Contains(searchTerm) ||
                           u.FirstName.Contains(searchTerm) ||
                           u.LastName.Contains(searchTerm))
                .ToListAsync();
        }

        public async Task<bool> IsEmailUniqueAsync(string email, string excludeUserId = null)
        {
            var query = _dbSet.Where(u => u.Email == email);
            if (!string.IsNullOrEmpty(excludeUserId))
            {
                query = query.Where(u => u.Id != excludeUserId);
            }
            return !await query.AnyAsync();
        }

        public async Task<bool> UserExistsAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return false;

            return await _dbSet.AnyAsync(u => u.Id == userId);
        }
    }
}