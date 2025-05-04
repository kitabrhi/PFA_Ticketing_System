using Ticketing_System.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ticketing_System.Repository.Interfaces
{
    public interface IAssignmentRuleRepository : IRepository<AssignmentRule>
    {
        Task<IEnumerable<AssignmentRule>> GetActiveRulesAsync();
        Task<IEnumerable<AssignmentRule>> GetRulesByCategoryAndPriorityAsync(TicketCategory? category, TicketPriority? priority);
        Task<AssignmentRule> GetHighestPriorityMatchingRuleAsync(TicketCategory? category, TicketPriority? priority);
    }
}
