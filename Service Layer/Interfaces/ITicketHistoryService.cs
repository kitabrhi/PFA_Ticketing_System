using Ticketing_System.Models;

namespace Ticketing_System.Service_Layer.Interfaces
{
    public interface ITicketHistoryService
    {
        Task<IEnumerable<TicketHistory>> GetHistoryByTicketIdAsync(int ticketId);
        Task<TicketHistory> AddHistoryEntryAsync(TicketHistory history);
    }
}
