using Ticketing_System.Models;

namespace Ticketing_System.Service_Layer.Interfaces
{
    public interface ITicketCommentService
    {
        Task<IEnumerable<TicketComment>> GetCommentsByTicketIdAsync(int ticketId);
        Task<TicketComment> AddCommentAsync(TicketComment comment);
        Task<TicketComment> GetCommentByIdAsync(int commentId);
        Task UpdateCommentAsync(TicketComment comment);
        Task DeleteCommentAsync(int commentId);
        Task<IEnumerable<TicketComment>> GetPublicCommentsByTicketIdAsync(int ticketId);
        Task<IEnumerable<TicketComment>> GetInternalCommentsByTicketIdAsync(int ticketId);
    }
}
