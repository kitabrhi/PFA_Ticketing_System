using Ticketing_System.Models;

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

    // Méthode pour distribuer les tickets en fonction de la charge de travail
    Task AssignTicketToLeastBusyAgentAsync(int ticketId);

    // Méthode unifiée pour l'assignation automatique
    Task AssignTicketAutomaticallyAsync(int ticketId);
}