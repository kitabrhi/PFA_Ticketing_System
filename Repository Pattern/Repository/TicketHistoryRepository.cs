using Ticketing_System.Models;
using Ticketing_System;
using Microsoft.EntityFrameworkCore;

public class TicketHistoryRepository : Repository<TicketHistory>, ITicketHistoryRepository
{
    public TicketHistoryRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<TicketHistory>> GetHistoryByTicketIdAsync(int ticketId)
    {
        return await _dbSet
            .Where(h => h.TicketID == ticketId)
            .OrderByDescending(h => h.ChangedDate)
            .ToListAsync();
    }
}