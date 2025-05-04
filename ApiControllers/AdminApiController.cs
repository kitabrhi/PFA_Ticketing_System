using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketing_System.Models;
using Ticketing_System.Service_Layer.Interfaces;

namespace Ticketing_System.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminApiController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        public AdminApiController(
            IUserService userService,
            RoleManager<Role> roleManager,
            UserManager<User> userManager)
        {
            _userService = userService;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // GET: api/AdminApi/Users
        [HttpGet("Users")]
        public async Task<IActionResult> Users(string searchTerm = "")
        {
            IEnumerable<User> users;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                users = await _userService.SearchUsersAsync(searchTerm);
            }
            else
            {
                users = await _userService.GetAllUsersAsync();
            }

            // Pour chaque utilisateur, obtenir ses rôles
            var userRoles = new Dictionary<string, IEnumerable<string>>();
            foreach (var user in users)
            {
                userRoles[user.Id] = await _userService.GetUserRolesAsync(user.Id);
            }

            var result = users.Select(u => new
            {
                u.Id,
                u.FirstName,
                u.LastName,
                u.Email,
                u.UserName,
                u.PhoneNumber,
                u.CreatedDate,
                u.LastLoginDate,
                u.IsActive,
                Roles = userRoles.ContainsKey(u.Id) ? userRoles[u.Id] : Enumerable.Empty<string>()
            });

            return Ok(result);
        }

        // GET: api/AdminApi/UserDetails/5
        [HttpGet("UserDetails/{id}")]
        public async Task<IActionResult> UserDetails(string id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                var userRoles = await _userService.GetUserRolesAsync(id);

                var result = new
                {
                    user.Id,
                    user.FirstName,
                    user.LastName,
                    user.Email,
                    user.UserName,
                    user.PhoneNumber,
                    user.CreatedDate,
                    user.LastLoginDate,
                    user.IsActive,
                    Roles = userRoles
                };

                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Utilisateur non trouvé" });
            }
        }

        // GET: api/AdminApi/EditUser/5
        [HttpGet("EditUser/{id}")]
        public async Task<IActionResult> EditUser(string id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                var userRoles = await _userService.GetUserRolesAsync(id);
                var allRoles = _roleManager.Roles.Select(r => r.Name).ToList();

                var result = new
                {
                    user,
                    Roles = userRoles,
                    AllRoles = allRoles
                };

                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Utilisateur non trouvé" });
            }
        }

        // PUT: api/AdminApi/EditUser/5
        // PUT: api/AdminApi/EditUser/5
[HttpPut("EditUser/{id}")]
public async Task<IActionResult> EditUser(string id, [FromBody] EditUserModel model)
{
    if (id != model.User.Id)
    {
        return BadRequest(new { message = "L'ID de l'utilisateur ne correspond pas" });
    }

    try
    {
        await _userService.UpdateUserAsync(model.User);

        if (model.SelectedRoles != null)
        {
            await _userService.UpdateUserRolesAsync(id, model.SelectedRoles);
        }

        return Ok(new { success = true, message = "Utilisateur mis à jour avec succès" });
    }
    catch (KeyNotFoundException)
    {
        return NotFound(new { message = "Utilisateur non trouvé" });
    }
    catch (Exception ex)
    {
        return StatusCode(500, new { message = $"Erreur lors de la mise à jour de l'utilisateur: {ex.Message}" });
    }
}

// Ajoutez cette classe dans le même fichier
public class EditUserModel
{
    public User User { get; set; }
    public string[] SelectedRoles { get; set; }
}
        // GET: api/AdminApi/DeleteUser/5
        [HttpGet("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                var userRoles = await _userService.GetUserRolesAsync(id);

                var result = new
                {
                    user,
                    Roles = userRoles
                };

                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Utilisateur non trouvé" });
            }
        }

        // DELETE: api/AdminApi/DeleteUserConfirmed/5
        [HttpDelete("DeleteUserConfirmed/{id}")]
        public async Task<IActionResult> DeleteUserConfirmed(string id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return Ok(new { success = true, message = "Utilisateur désactivé avec succès" });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Utilisateur non trouvé" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Erreur lors de la désactivation de l'utilisateur: {ex.Message}" });
            }
        }

        // GET: api/AdminApi/CreateUser
        [HttpGet("CreateUser")]
        public IActionResult CreateUser()
        {
            var allRoles = _roleManager.Roles.Select(r => r.Name).ToList();
            return Ok(new { Roles = allRoles });
        }

        // POST: api/AdminApi/CreateUser
       // POST: api/AdminApi/CreateUser
[HttpPost("CreateUser")]
public async Task<IActionResult> CreateUser([FromBody] CreateUserModel model)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    model.User.UserName = model.User.Email;
    model.User.CreatedDate = DateTime.Now;
    model.User.IsActive = true;

    var result = await _userManager.CreateAsync(model.User, model.Password);
    if (result.Succeeded)
    {
        if (model.SelectedRoles != null && model.SelectedRoles.Any())
        {
            await _userManager.AddToRolesAsync(model.User, model.SelectedRoles);
        }

        return Ok(new { success = true, userId = model.User.Id, message = "Utilisateur créé avec succès" });
    }

    foreach (var error in result.Errors)
    {
        ModelState.AddModelError("", error.Description);
    }

    return BadRequest(ModelState);
}

// Ajoutez cette classe dans le même fichier
public class CreateUserModel
{
    public User User { get; set; }
    public string Password { get; set; }
    public string[] SelectedRoles { get; set; }
}
    }
}