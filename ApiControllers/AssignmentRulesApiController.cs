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
    public class AssignmentRulesApiController : ControllerBase
    {
        private readonly IAssignmentRuleService _ruleService;

        public AssignmentRulesApiController(IAssignmentRuleService ruleService)
        {
            _ruleService = ruleService;
        }

        // GET: api/AssignmentRules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssignmentRule>>> GetRules()
        {
            var rules = await _ruleService.GetAllRulesAsync();
            return Ok(rules);
        }

        // GET: api/AssignmentRules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssignmentRule>> GetRule(int id)
        {
            try
            {
                var rule = await _ruleService.GetRuleByIdAsync(id);
                return Ok(rule);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/AssignmentRules
        [HttpPost]
        public async Task<ActionResult<AssignmentRule>> CreateRule(AssignmentRule rule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdRule = await _ruleService.CreateRuleAsync(rule);
                return CreatedAtAction(nameof(GetRule), new { id = createdRule.RuleID }, createdRule);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/AssignmentRules/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRule(int id, AssignmentRule rule)
        {
            if (id != rule.RuleID)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _ruleService.UpdateRuleAsync(rule);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/AssignmentRules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRule(int id)
        {
            try
            {
                await _ruleService.DeleteRuleAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // POST: api/AssignmentRules/Apply/5
        [HttpPost("Apply/{ticketId}")]
        public async Task<IActionResult> ApplyRuleToTicket(int ticketId)
        {
            try
            {
                await _ruleService.ApplyRuleToTicketAsync(ticketId);
                return Ok(new { message = "Assignment rules applied successfully" });
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}