using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketing_System.Models;
using Ticketing_System.Repository.Interfaces;

namespace Ticketing_System.Repository
{
    public class AssignmentRuleRepository : Repository<AssignmentRule>, IAssignmentRuleRepository
    {
        public AssignmentRuleRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<AssignmentRule>> GetActiveRulesAsync()
        {
            return await _dbSet
                .Where(r => r.IsActive)
                .Include(r => r.AssignToTeam)
                .Include(r => r.AssignToUser)
                .OrderBy(r => r.RuleOrder)
                .ToListAsync();
        }

        public async Task<IEnumerable<AssignmentRule>> GetRulesByCategoryAndPriorityAsync(
            TicketCategory? category, TicketPriority? priority)
        {
            var query = _dbSet.Where(r => r.IsActive);
            
            if (category.HasValue)
            {
                query = query.Where(r => r.Category == null || r.Category == category.Value);
            }
            
            if (priority.HasValue)
            {
                query = query.Where(r => r.Priority == null || r.Priority == priority.Value);
            }
            
            return await query
                .Include(r => r.AssignToTeam)
                .Include(r => r.AssignToUser)
                .OrderBy(r => r.RuleOrder)
                .ToListAsync();
        }

        public async Task<AssignmentRule> GetHighestPriorityMatchingRuleAsync(
            TicketCategory? category, TicketPriority? priority)
        {
            return await _dbSet
                .Where(r => r.IsActive)
                .Where(r => r.Category == null || r.Category == category)
                .Where(r => r.Priority == null || r.Priority == priority)
                .Include(r => r.AssignToTeam)
                .Include(r => r.AssignToUser)
                .OrderBy(r => r.RuleOrder)
                .FirstOrDefaultAsync();
        }
    }
}
