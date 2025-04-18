using Ticketing_System.Models;
using Ticketing_System;
using Microsoft.EntityFrameworkCore;

public class TicketCommentRepository : Repository<TicketComment>, ITicketCommentRepository
{
    public TicketCommentRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<TicketComment>> GetCommentsByTicketIdAsync(int ticketId)
    {
        return await _dbSet
            .Where(c => c.TicketID == ticketId)
            .Include(c => c.User)
            .OrderBy(c => c.CreatedDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<TicketComment>> GetPublicCommentsByTicketIdAsync(int ticketId)
    {
        return await _dbSet
            .Where(c => c.TicketID == ticketId && !c.IsInternal)
            .Include(c => c.User)
            .OrderBy(c => c.CreatedDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<TicketComment>> GetInternalCommentsByTicketIdAsync(int ticketId)
    {
        return await _dbSet
            .Where(c => c.TicketID == ticketId && c.IsInternal)
            .Include(c => c.User)
            .OrderBy(c => c.CreatedDate)
            .ToListAsync();
    }
}
