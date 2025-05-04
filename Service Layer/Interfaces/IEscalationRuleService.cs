using System.Collections.Generic;
using System.Threading.Tasks;
using Ticketing_System.Models;

namespace Ticketing_System.Service_Layer.Interfaces
{
    public interface IEscalationRuleService
    {
        Task<IEnumerable<EscalationRule>> GetAllRulesAsync();
        Task<EscalationRule> GetRuleByIdAsync(int ruleId);
        Task<EscalationRule> CreateRuleAsync(EscalationRule rule);
        Task UpdateRuleAsync(EscalationRule rule);
        Task DeleteRuleAsync(int ruleId);
        Task<bool> CheckAndEscalateTicketAsync(int ticketId);
        Task<IEnumerable<Ticket>> GetTicketsNeedingEscalationAsync();
        Task EscalateTicketAsync(int ticketId, EscalationRule rule);
    }
}
