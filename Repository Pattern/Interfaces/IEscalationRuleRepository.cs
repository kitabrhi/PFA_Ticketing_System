using Ticketing_System.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ticketing_System.Repository.Interfaces
{
    public interface IEscalationRuleRepository : IRepository<EscalationRule>
    {
        Task<IEnumerable<EscalationRule>> GetActiveRulesAsync();
        Task<IEnumerable<EscalationRule>> GetRulesByPriorityAndStatusAsync(TicketPriority? priority, TicketStatus? status);
        Task<EscalationRule> GetMatchingRuleAsync(TicketPriority? priority, TicketStatus? status);
    }
}
