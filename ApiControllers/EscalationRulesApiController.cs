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
    public class EscalationRulesApiController : ControllerBase
    {
        private readonly IEscalationRuleService _ruleService;

        public EscalationRulesApiController(IEscalationRuleService ruleService)
        {
            _ruleService = ruleService;
        }

        // GET: api/EscalationRules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EscalationRule>>> GetRules()
        {
            var rules = await _ruleService.GetAllRulesAsync();
            return Ok(rules);
        }

        // GET: api/EscalationRules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EscalationRule>> GetRule(int id)
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

        // POST: api/EscalationRules
        [HttpPost]
        public async Task<ActionResult<EscalationRule>> CreateRule(EscalationRule rule)
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

        // PUT: api/EscalationRules/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRule(int id, EscalationRule rule)
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

        // DELETE: api/EscalationRules/5
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

        // GET: api/EscalationRules/TicketsNeedingEscalation
        [HttpGet("TicketsNeedingEscalation")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTicketsNeedingEscalation()
        {
            var tickets = await _ruleService.GetTicketsNeedingEscalationAsync();
            return Ok(tickets);
        }

        // POST: api/EscalationRules/Escalate/5
        [HttpPost("Escalate/{ticketId}")]
        public async Task<IActionResult> EscalateTicket(int ticketId)
        {
            try
            {
                var escalated = await _ruleService.CheckAndEscalateTicketAsync(ticketId);
                if (escalated)
                {
                    return Ok(new { message = "Ticket escalated successfully" });
                }
                else
                {
                    return Ok(new { message = "Ticket did not meet escalation criteria" });
                }
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