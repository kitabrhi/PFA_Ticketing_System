using System.Collections.Generic;
using System.Threading.Tasks;
using Ticketing_System.Models;

namespace Ticketing_System.Service_Layer.Interfaces
{
    public interface IAssignmentRuleService
    {
        Task<IEnumerable<AssignmentRule>> GetAllRulesAsync();
        Task<AssignmentRule> GetRuleByIdAsync(int ruleId);
        Task<AssignmentRule> CreateRuleAsync(AssignmentRule rule);
        Task UpdateRuleAsync(AssignmentRule rule);
        Task DeleteRuleAsync(int ruleId);
        Task<AssignmentRule> GetMatchingRuleForTicketAsync(Ticket ticket);
        Task ApplyRuleToTicketAsync(int ticketId);
        Task AutoAssignTicketAsync(Ticket ticket);
    }
}
