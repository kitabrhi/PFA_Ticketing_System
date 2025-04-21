using Microsoft.AspNetCore.Identity;
using Ticketing_System.Models;
using Ticketing_System.Repository.Interfaces;
using Ticketing_System.Repository_Pattern.Interfaces;
using Ticketing_System.Service_Layer.Interfaces;

namespace Ticketing_System.Service_Layer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public UserService(IUserRepository userRepository, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task<IEnumerable<User>> GetUsersByRoleAsync(string roleName)
        {
            return await _userRepository.GetUsersByRoleAsync(roleName);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            return await _userRepository.UpdateUserInfoAsync(user);
        }

        public async Task<bool> DeactivateUserAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId)) throw new ArgumentNullException(nameof(userId));

            return await _userRepository.DeactivateUserAsync(userId);
        }

        public async Task<bool> UpdateProfileAsync(User userProfile)
        {
            if (userProfile == null) throw new ArgumentNullException(nameof(userProfile));

            var existingUser = await _userRepository.GetUserByIdAsync(userProfile.Id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {userProfile.Id} not found");
            }

            // Check if new email is unique
            if (existingUser.Email != userProfile.Email)
            {
                if (!await _userRepository.IsEmailUniqueAsync(userProfile.Email, userProfile.Id))
                {
                    throw new InvalidOperationException("Email is already in use");
                }
            }

            return await _userRepository.UpdateUserInfoAsync(userProfile);
        }

        public async Task<bool> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {userId} not found");
            }

            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
            return result.Succeeded;
        }

        public async Task<IEnumerable<User>> SearchUsersAsync(string searchTerm)
        {
            return await _userRepository.SearchUsersAsync(searchTerm);
        }

        public async Task<bool> IsEmailUniqueAsync(string email, string excludeUserId = null)
        {
            return await _userRepository.IsEmailUniqueAsync(email, excludeUserId);
        }

        public async Task<IEnumerable<string>> GetUserRolesAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {userId} not found");
            }

            return await _userManager.GetRolesAsync(user);
        }

        public async Task<bool> UpdateUserRolesAsync(string userId, IEnumerable<string> roles)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {userId} not found");
            }

            var currentRoles = await _userManager.GetRolesAsync(user);
            var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
            if (!removeResult.Succeeded)
            {
                return false;
            }

            var addResult = await _userManager.AddToRolesAsync(user, roles);
            return addResult.Succeeded;
        }
    }
}