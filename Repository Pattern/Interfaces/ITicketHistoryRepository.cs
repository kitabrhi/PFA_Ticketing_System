using Ticketing_System.Models;

public interface ITicketHistoryRepository : IRepository<TicketHistory>
{
    Task<IEnumerable<TicketHistory>> GetHistoryByTicketIdAsync(int ticketId);
}