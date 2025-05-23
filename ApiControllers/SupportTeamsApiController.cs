using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ticketing_System.Models;
using Ticketing_System.Service_Layer.Interfaces;

namespace Ticketing_System.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportTeamsApiController : ControllerBase
    {
        private readonly ISupportTeamService _teamService;

        public SupportTeamsApiController(ISupportTeamService teamService)
        {
            _teamService = teamService;
        }

        // GET: api/SupportTeams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupportTeam>>> GetTeams()
        {
            var teams = await _teamService.GetAllAsync();
            return Ok(teams);
        }

        // GET: api/SupportTeams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupportTeam>> GetTeam(int id)
        {
            var team = await _teamService.GetByIdAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

       

       

        // DELETE: api/SupportTeams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = await _teamService.GetByIdAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            try
            {
                await _teamService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}