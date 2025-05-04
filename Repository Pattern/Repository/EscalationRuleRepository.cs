using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketing_System.Models;
using Ticketing_System.Repository.Interfaces;

namespace Ticketing_System.Repository
{
    public class EscalationRuleRepository : Repository<EscalationRule>, IEscalationRuleRepository
    {
        public EscalationRuleRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EscalationRule>> GetActiveRulesAsync()
        {
            return await _dbSet
                .Where(r => r.IsActive)
                .Include(r => r.EscalateToUser)
                .Include(r => r.EscalateToTeam)
                .ToListAsync();
        }

        public async Task<IEnumerable<EscalationRule>> GetRulesByPriorityAndStatusAsync(
            TicketPriority? priority, TicketStatus? status)
        {
            var query = _dbSet.Where(r => r.IsActive);

            if (priority.HasValue)
            {
                query = query.Where(r => r.Priority == null || r.Priority == priority.Value);
            }

            if (status.HasValue)
            {
                query = query.Where(r => r.Status == null || r.Status == status.Value);
            }

            return await query
                .Include(r => r.EscalateToUser)
                .Include(r => r.EscalateToTeam)
                .ToListAsync();
        }

        public async Task<EscalationRule> GetMatchingRuleAsync(
            TicketPriority? priority, TicketStatus? status)
        {
            return await _dbSet
                .Where(r => r.IsActive)
                .Where(r => r.Priority == null || r.Priority == priority)
                .Where(r => r.Status == null || r.Status == status)
                .Include(r => r.EscalateToUser)
                .Include(r => r.EscalateToTeam)
                .FirstOrDefaultAsync();
        }
    }
}
