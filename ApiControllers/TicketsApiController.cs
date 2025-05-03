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
    public class TicketsApiController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly ITicketCommentService _commentService;
        private readonly ITicketHistoryService _historyService;
        private readonly IAttachmentService _attachmentService;

        public TicketsApiController(
            ITicketService ticketService,
            ITicketCommentService commentService,
            ITicketHistoryService historyService,
            IAttachmentService attachmentService)
        {
            _ticketService = ticketService;
            _commentService = commentService;
            _historyService = historyService;
            _attachmentService = attachmentService;
        }

        // GET: api/TicketsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
        {
            var tickets = await _ticketService.GetAllTicketsAsync();
            return Ok(tickets);
        }

        // GET: api/TicketsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            try
            {
                var ticket = await _ticketService.GetTicketByIdAsync(id);
                return Ok(ticket);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/TicketsApi
        [HttpPost]
        public async Task<ActionResult<Ticket>> CreateTicket(Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdTicket = await _ticketService.CreateTicketAsync(ticket);
                return CreatedAtAction(nameof(GetTicket), new { id = createdTicket.TicketID }, createdTicket);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/TicketsApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, Ticket ticket)
        {
            if (id != ticket.TicketID)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _ticketService.UpdateTicketAsync(ticket);
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

        // DELETE: api/TicketsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            try
            {
                await _ticketService.DeleteTicketAsync(id);
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

        // GET: api/TicketsApi/MyTickets
        [HttpGet("MyTickets")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetMyTickets(string userId)
        {
            var tickets = await _ticketService.GetTicketsByUserIdAsync(userId);
            return Ok(tickets);
        }

        // GET: api/TicketsApi/AssignedTickets
        [HttpGet("AssignedTickets")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetAssignedTickets(string userId)
        {
            var tickets = await _ticketService.GetTicketsByAssignedUserIdAsync(userId);
            return Ok(tickets);
        }

        // PATCH: api/TicketsApi/5/Status
        [HttpPatch("{id}/Status")]
        public async Task<ActionResult<Ticket>> ChangeTicketStatus(int id, [FromBody] TicketStatus status, string userId)
        {
            try
            {
                var ticket = await _ticketService.ChangeTicketStatusAsync(id, status, userId);
                return Ok(ticket);
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

        // PATCH: api/TicketsApi/5/AssignUser
        [HttpPatch("{id}/AssignUser")]
        public async Task<ActionResult<Ticket>> AssignTicketToUser(int id, [FromBody] string userId, string updatedByUserId)
        {
            try
            {
                var ticket = await _ticketService.AssignTicketAsync(id, userId, updatedByUserId);
                return Ok(ticket);
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

        // PATCH: api/TicketsApi/5/AssignTeam
        [HttpPatch("{id}/AssignTeam")]
        public async Task<ActionResult<Ticket>> AssignTicketToTeam(int id, [FromBody] int teamId, string updatedByUserId)
        {
            try
            {
                var ticket = await _ticketService.AssignTicketToTeamAsync(id, teamId, updatedByUserId);
                return Ok(ticket);
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

        // GET: api/TicketsApi/5/Comments
        [HttpGet("{id}/Comments")]
        public async Task<ActionResult<IEnumerable<TicketComment>>> GetTicketComments(int id)
        {
            try
            {
                var comments = await _commentService.GetCommentsByTicketIdAsync(id);
                return Ok(comments);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // POST: api/TicketsApi/5/Comments
        [HttpPost("{id}/Comments")]
        public async Task<ActionResult<TicketComment>> AddComment(int id, TicketComment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            comment.TicketID = id;
            
            try
            {
                var createdComment = await _commentService.AddCommentAsync(comment);
                return CreatedAtAction(nameof(GetTicketComments), new { id = id }, createdComment);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET: api/TicketsApi/5/History
        [HttpGet("{id}/History")]
        public async Task<ActionResult<IEnumerable<TicketHistory>>> GetTicketHistory(int id)
        {
            try
            {
                var history = await _historyService.GetHistoryByTicketIdAsync(id);
                return Ok(history);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET: api/TicketsApi/5/Attachments
        [HttpGet("{id}/Attachments")]
        public async Task<ActionResult<IEnumerable<Attachment>>> GetTicketAttachments(int id)
        {
            try
            {
                var attachments = await _attachmentService.GetAttachmentsByTicketIdAsync(id);
                return Ok(attachments);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}