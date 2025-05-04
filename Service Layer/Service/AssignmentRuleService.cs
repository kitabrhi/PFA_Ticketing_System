using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ticketing_System.Models;
using Ticketing_System.Repository.Interfaces;
using Ticketing_System.Service_Layer.Interfaces;

namespace Ticketing_System.Service_Layer.Service
{
    public class AssignmentRuleService : IAssignmentRuleService
    {
        private readonly IAssignmentRuleRepository _ruleRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly ITicketHistoryService _historyService;

        public AssignmentRuleService(
            IAssignmentRuleRepository ruleRepository,
            ITicketRepository ticketRepository,
            ITicketHistoryService historyService)
        {
            _ruleRepository = ruleRepository;
            _ticketRepository = ticketRepository;
            _historyService = historyService;
        }

        public async Task<IEnumerable<AssignmentRule>> GetAllRulesAsync()
        {
            return await _ruleRepository.GetAllAsync();
        }

        public async Task<AssignmentRule> GetRuleByIdAsync(int ruleId)
        {
            var rule = await _ruleRepository.GetByIdAsync(ruleId);
            if (rule == null)
            {
                throw new KeyNotFoundException($"Assignment rule with ID {ruleId} not found");
            }
            return rule;
        }

        public async Task<AssignmentRule> CreateRuleAsync(AssignmentRule rule)
        {
            if (rule == null) throw new ArgumentNullException(nameof(rule));

            // Vérifier qu'il y a au moins un assignee
            if (string.IsNullOrEmpty(rule.AssignToUserID) && !rule.AssignToTeamID.HasValue)
            {
                throw new ArgumentException("Rule must have either a user or team assignment");
            }

            // Définir l'ordre si non spécifié
            if (rule.RuleOrder == 0)
            {
                var existingRules = await _ruleRepository.GetAllAsync();
                rule.RuleOrder = existingRules.Count() + 1;
            }

            return await _ruleRepository.AddAsync(rule);
        }

        public async Task UpdateRuleAsync(AssignmentRule rule)
        {
            if (rule == null) throw new ArgumentNullException(nameof(rule));

            var existingRule = await _ruleRepository.GetByIdAsync(rule.RuleID);
            if (existingRule == null)
            {
                throw new KeyNotFoundException($"Assignment rule with ID {rule.RuleID} not found");
            }

            await _ruleRepository.UpdateAsync(rule);
        }

        public async Task DeleteRuleAsync(int ruleId)
        {
            var rule = await _ruleRepository.GetByIdAsync(ruleId);
            if (rule == null)
            {
                throw new KeyNotFoundException($"Assignment rule with ID {ruleId} not found");
            }

            await _ruleRepository.DeleteAsync(rule);
        }

        public async Task<AssignmentRule> GetMatchingRuleForTicketAsync(Ticket ticket)
        {
            if (ticket == null) throw new ArgumentNullException(nameof(ticket));

            return await _ruleRepository.GetHighestPriorityMatchingRuleAsync(
                ticket.Category, ticket.Priority);
        }

        public async Task ApplyRuleToTicketAsync(int ticketId)
        {
            var ticket = await _ticketRepository.GetByIdAsync(ticketId);
            if (ticket == null)
            {
                throw new KeyNotFoundException($"Ticket with ID {ticketId} not found");
            }

            var matchingRule = await GetMatchingRuleForTicketAsync(ticket);
            if (matchingRule != null)
            {
                // Sauvegarder l'état actuel avant modification
                string oldAssignedUserId = ticket.AssignedToUserId;
                int? oldAssignedTeamId = ticket.AssignedToTeamID;

                // Appliquer la règle
                ticket.AssignedToUserId = matchingRule.AssignToUserID;
                ticket.AssignedToTeamID = matchingRule.AssignToTeamID;
                ticket.UpdatedDate = DateTime.Now;

                await _ticketRepository.UpdateAsync(ticket);

                // Enregistrer l'historique
                if (oldAssignedUserId != ticket.AssignedToUserId)
                {
                    await _historyService.AddHistoryEntryAsync(new TicketHistory
                    {
                        TicketID = ticketId,
                        ChangedByUserId = "SYSTEM", // Utilisateur système
                        FieldName = "AssignedToUser",
                        OldValue = oldAssignedUserId ?? "Unassigned",
                        NewValue = ticket.AssignedToUserId ?? "Unassigned",
                        ChangedDate = DateTime.Now
                    });
                }

                if (oldAssignedTeamId != ticket.AssignedToTeamID)
                {
                    await _historyService.AddHistoryEntryAsync(new TicketHistory
                    {
                        TicketID = ticketId,
                        ChangedByUserId = "SYSTEM",
                        FieldName = "AssignedToTeam",
                        OldValue = oldAssignedTeamId?.ToString() ?? "Unassigned",
                        NewValue = ticket.AssignedToTeamID?.ToString() ?? "Unassigned",
                        ChangedDate = DateTime.Now
                    });
                }
            }
        }

        public async Task AutoAssignTicketAsync(Ticket ticket)
        {
            if (ticket == null) throw new ArgumentNullException(nameof(ticket));

            var matchingRule = await GetMatchingRuleForTicketAsync(ticket);
            if (matchingRule != null)
            {
                ticket.AssignedToUserId = matchingRule.AssignToUserID;
                ticket.AssignedToTeamID = matchingRule.AssignToTeamID;
            }
        }
    }
}
