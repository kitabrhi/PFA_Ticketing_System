using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Ticketing_System.Models;
using Ticketing_System.Service_Layer.Interfaces;

namespace Ticketing_System.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Profile
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userService.GetUserByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            ViewBag.UserRoles = await _userService.GetUserRolesAsync(userId);
            return View(user);
        }

        // GET: Profile/Edit
        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userService.GetUserByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Profile/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(User userProfile)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // S'assurer que l'utilisateur ne modifie que son propre profil
            if (userId != userProfile.Id)
            {
                return Unauthorized();
            }

            // Supprimer les validations de champs non modifiables
            ModelState.Remove("UserName");
            ModelState.Remove("PasswordHash");
            ModelState.Remove("CreatedDate");
            ModelState.Remove("IsActive");
            ModelState.Remove("Comments");
            ModelState.Remove("Articles");
            ModelState.Remove("Attachments");
            ModelState.Remove("ManagedTeams");
            ModelState.Remove("Notifications");
            ModelState.Remove("TicketChanges");
            ModelState.Remove("CreatedTickets");
            ModelState.Remove("AssignedTickets");
            ModelState.Remove("TeamMemberships");

            if (!ModelState.IsValid)
            {
                return View(userProfile);
            }

            try
            {
                var success = await _userService.UpdateProfileAsync(userProfile);

                if (success)
                {
                    TempData["SuccessMessage"] = "Profile updated successfully!";
                    return RedirectToAction(nameof(Index));
                }

                TempData["ErrorMessage"] = "Failed to update profile.";
                return View(userProfile);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("Email", ex.Message);
                return View(userProfile);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while updating your profile.");
                return View(userProfile);
            }
        }

        // GET: Profile/ChangePassword
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        // POST: Profile/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var success = await _userService.ChangePasswordAsync(userId, model.CurrentPassword, model.NewPassword);

                if (success)
                {
                    TempData["SuccessMessage"] = "Password changed successfully!";
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", "Failed to change password. Please check your current password.");
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while changing your password.");
                return View(model);
            }
        }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}