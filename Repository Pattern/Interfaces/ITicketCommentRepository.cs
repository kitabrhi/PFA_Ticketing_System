using Ticketing_System.Models;

public interface ITicketCommentRepository : IRepository<TicketComment>
{
    Task<IEnumerable<TicketComment>> GetCommentsByTicketIdAsync(int ticketId);
    Task<IEnumerable<TicketComment>> GetPublicCommentsByTicketIdAsync(int ticketId);
    Task<IEnumerable<TicketComment>> GetInternalCommentsByTicketIdAsync(int ticketId);
}