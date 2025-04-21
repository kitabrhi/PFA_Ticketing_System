using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ticketing_System.Models;
using Ticketing_System.Service_Layer.Interfaces;

namespace Ticketing_System.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        public AdminController(
            IUserService userService,
            RoleManager<Role> roleManager,
            UserManager<User> userManager)
        {
            _userService = userService;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // GET: Admin/Users
        [HttpGet]
        public async Task<IActionResult> Users(string searchTerm = "")
        {
            IEnumerable<User> users;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                users = await _userService.SearchUsersAsync(searchTerm);
                ViewBag.SearchTerm = searchTerm;
            }
            else
            {
                users = await _userService.GetAllUsersAsync();
            }

            // For each user, get their roles
            var userRoles = new Dictionary<string, IEnumerable<string>>();
            foreach (var user in users)
            {
                userRoles[user.Id] = await _userService.GetUserRolesAsync(user.Id);
            }

            ViewBag.UserRoles = userRoles;
            return View(users);
        }

        // GET: Admin/UserDetails/5
        [HttpGet]
        public async Task<IActionResult> UserDetails(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            ViewBag.UserRoles = await _userService.GetUserRolesAsync(id);
            return View(user);
        }

        // GET: Admin/EditUser/5
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var userRoles = await _userService.GetUserRolesAsync(id);
            var allRoles = _roleManager.Roles.Select(r => r.Name).ToList();

            ViewBag.Roles = new MultiSelectList(allRoles, userRoles);
            return View(user);
        }

        // POST: Admin/EditUser/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(string id, User user, string[] selectedRoles)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            try
            {
                await _userService.UpdateUserAsync(user);

                if (selectedRoles != null)
                {
                    await _userService.UpdateUserRolesAsync(id, selectedRoles);
                }

                TempData["SuccessMessage"] = "User updated successfully!";
                return RedirectToAction(nameof(Users));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                var allRoles = _roleManager.Roles.Select(r => r.Name).ToList();
                ViewBag.Roles = new MultiSelectList(allRoles, selectedRoles);
                return View(user);
            }
        }

        // GET: Admin/DeleteUser/5
        [HttpGet]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            ViewBag.UserRoles = await _userService.GetUserRolesAsync(id);
            return View(user);
        }

        // POST: Admin/DeleteUser/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUserConfirmed(string id)
        {
            try
            {
                await _userService.DeactivateUserAsync(id);
                TempData["SuccessMessage"] = "User deactivated successfully!";
                return RedirectToAction(nameof(Users));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Users));
            }
        }


        // GET: Admin/CreateUser
        [HttpGet]
        public IActionResult CreateUser()
        {
            var allRoles = _roleManager.Roles.Select(r => r.Name).ToList();
            ViewBag.Roles = new MultiSelectList(allRoles);
            return View();
        }

        // POST: Admin/CreateUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(User user, string password, string[] selectedRoles)
        {
            ModelState.Remove("Comments");
            ModelState.Remove("Articles");
            ModelState.Remove("Attachments");
            ModelState.Remove("ManagedTeams");
            ModelState.Remove("Notifications");
            ModelState.Remove("TicketChanges");
            ModelState.Remove("CreatedTickets");
            ModelState.Remove("AssignedTickets");
            ModelState.Remove("TeamMemberships");
            if (ModelState.IsValid)
            {
                user.UserName = user.Email;
                user.CreatedDate = DateTime.Now;
                user.IsActive = true;

                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    if (selectedRoles != null && selectedRoles.Any())
                    {
                        await _userManager.AddToRolesAsync(user, selectedRoles);
                    }

                    TempData["SuccessMessage"] = "User created successfully!";
                    return RedirectToAction(nameof(Users));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            var allRoles = _roleManager.Roles.Select(r => r.Name).ToList();
            ViewBag.Roles = new MultiSelectList(allRoles, selectedRoles);
            return View(user);
        }
    }
}