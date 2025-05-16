using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public AssignmentRuleService(
            IAssignmentRuleRepository ruleRepository,
            ITicketRepository ticketRepository,
            ITicketHistoryService historyService,
            UserManager<User> userManager,
            ApplicationDbContext context)
        {
            _ruleRepository = ruleRepository;
            _ticketRepository = ticketRepository;
            _historyService = historyService;
            _userManager = userManager;
            _context = context;
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

            // Rechercher la règle correspondante avec la priorité la plus élevée (ordre le plus bas)
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
                if (!string.IsNullOrEmpty(matchingRule.AssignToUserID))
                {
                    // Si la règle spécifie un utilisateur, assigner directement
                    ticket.AssignedToUserId = matchingRule.AssignToUserID;

                    // Au lieu de mettre AssignedToTeamID à null, trouver l'équipe de l'agent
                    var teamMember = await _context.TeamMembers
                        .FirstOrDefaultAsync(tm => tm.UserId == matchingRule.AssignToUserID);

                    if (teamMember != null)
                    {
                        ticket.AssignedToTeamID = teamMember.TeamID;
                    }
                    else
                    {
                        ticket.AssignedToTeamID = null;
                    }
                }
                else if (matchingRule.AssignToTeamID.HasValue)
                {
                    // Si la règle spécifie une équipe, assigner l'équipe
                    ticket.AssignedToTeamID = matchingRule.AssignToTeamID;

                    // Rechercher l'agent le moins chargé dans cette équipe
                    await AssignToLeastBusyAgentInTeam(ticket, matchingRule.AssignToTeamID.Value);
                }

                ticket.UpdatedDate = DateTime.Now;
                await _ticketRepository.UpdateAsync(ticket);

                // Enregistrer les modifications dans l'historique
                if (oldAssignedUserId != ticket.AssignedToUserId)
                {
                    await _historyService.AddHistoryEntryAsync(new TicketHistory
                    {
                        TicketID = ticketId,
                        ChangedByUserId = "SYSTEM",
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

            // Si le ticket n'a toujours pas d'utilisateur assigné, essayer d'assigner à n'importe quel agent
            if (string.IsNullOrEmpty(ticket.AssignedToUserId))
            {
                await AssignTicketToLeastBusyAgentAsync(ticketId);
            }
        }

        private async Task AssignToLeastBusyAgentInTeam(Ticket ticket, int teamId)
        {
            // Obtenir tous les membres de l'équipe
            var teamMembers = await _context.TeamMembers
                .Where(tm => tm.TeamID == teamId)
                .Select(tm => tm.UserId)
                .ToListAsync();

            if (teamMembers.Any())
            {
                // Filtrer pour ne garder que les agents de support
                var supportAgents = new List<User>();
                foreach (var userId in teamMembers)
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null && await _userManager.IsInRoleAsync(user, "SupportAgent"))
                    {
                        supportAgents.Add(user);
                    }
                }

                if (supportAgents.Any())
                {
                    // Calculer la charge de travail pour chaque agent
                    var workloads = new Dictionary<string, int>();
                    foreach (var agent in supportAgents)
                    {
                        var count = await _context.Tickets
                            .CountAsync(t => t.AssignedToUserId == agent.Id &&
                                         (t.Status == TicketStatus.New ||
                                          t.Status == TicketStatus.Open ||
                                          t.Status == TicketStatus.InProgress));
                        workloads.Add(agent.Id, count);
                    }

                    // Trouver l'agent avec la charge la plus faible
                    if (workloads.Any())
                    {
                        var leastBusyAgent = workloads.OrderBy(pair => pair.Value).First();
                        ticket.AssignedToUserId = leastBusyAgent.Key;
                        // Conserver l'assignation à l'équipe
                        ticket.AssignedToTeamID = teamId;
                    }
                    else
                    {
                        // Aucun agent n'a de tickets, assigner au premier
                        ticket.AssignedToUserId = supportAgents.First().Id;
                        // Conserver l'assignation à l'équipe
                        ticket.AssignedToTeamID = teamId;
                    }
                }
            }
        }

        public async Task AutoAssignTicketAsync(Ticket ticket)
        {
            if (ticket == null) throw new ArgumentNullException(nameof(ticket));

            var matchingRule = await GetMatchingRuleForTicketAsync(ticket);
            if (matchingRule != null)
            {
                if (!string.IsNullOrEmpty(matchingRule.AssignToUserID))
                {
                    // Si la règle spécifie un utilisateur, assigner directement
                    ticket.AssignedToUserId = matchingRule.AssignToUserID;

                    // Au lieu de mettre AssignedToTeamID à null, trouver l'équipe de l'agent
                    var teamMember = await _context.TeamMembers
                        .FirstOrDefaultAsync(tm => tm.UserId == matchingRule.AssignToUserID);

                    if (teamMember != null)
                    {
                        ticket.AssignedToTeamID = teamMember.TeamID;
                    }
                    else
                    {
                        ticket.AssignedToTeamID = null;
                    }
                }
                else if (matchingRule.AssignToTeamID.HasValue)
                {
                    // Si la règle spécifie une équipe, assigner l'équipe
                    ticket.AssignedToTeamID = matchingRule.AssignToTeamID;

                    // Rechercher l'agent le moins chargé dans cette équipe
                    await AssignToLeastBusyAgentInTeam(ticket, matchingRule.AssignToTeamID.Value);
                }
            }
        }

        public async Task AssignTicketToLeastBusyAgentAsync(int ticketId)
        {
            var ticket = await _ticketRepository.GetByIdAsync(ticketId);
            if (ticket == null)
            {
                throw new KeyNotFoundException($"Ticket with ID {ticketId} not found");
            }

            string oldAssignedUserId = ticket.AssignedToUserId;
            int? oldAssignedTeamId = ticket.AssignedToTeamID;

            // Si le ticket est déjà assigné à un agent, ne rien faire
            if (!string.IsNullOrEmpty(ticket.AssignedToUserId))
            {
                return;
            }

            // Obtenir tous les agents de support
            var supportAgents = await _userManager.GetUsersInRoleAsync("SupportAgent");

            // Si aucun agent n'est disponible, chercher des administrateurs
            if (!supportAgents.Any())
            {
                supportAgents = await _userManager.GetUsersInRoleAsync("Admin");
            }

            if (supportAgents.Any())
            {
                // Calculer la charge de travail pour chaque agent
                var workloads = new Dictionary<string, int>();
                foreach (var agent in supportAgents)
                {
                    var count = await _context.Tickets
                        .CountAsync(t => t.AssignedToUserId == agent.Id &&
                                     (t.Status == TicketStatus.New ||
                                      t.Status == TicketStatus.Open ||
                                      t.Status == TicketStatus.InProgress));
                    workloads.Add(agent.Id, count);
                }

                // Trouver l'agent avec la charge la plus faible
                if (workloads.Any())
                {
                    var leastBusyAgent = workloads.OrderBy(pair => pair.Value).First();
                    ticket.AssignedToUserId = leastBusyAgent.Key;

                    // Trouver si l'agent appartient à une équipe
                    var teamMember = await _context.TeamMembers
                        .FirstOrDefaultAsync(tm => tm.UserId == leastBusyAgent.Key);

                    if (teamMember != null)
                    {
                        ticket.AssignedToTeamID = teamMember.TeamID;
                    }

                    ticket.UpdatedDate = DateTime.Now;

                    await _ticketRepository.UpdateAsync(ticket);

                    // Enregistrer l'assignation d'utilisateur dans l'historique
                    await _historyService.AddHistoryEntryAsync(new TicketHistory
                    {
                        TicketID = ticketId,
                        ChangedByUserId = "SYSTEM",
                        FieldName = "AssignedToUser",
                        OldValue = oldAssignedUserId ?? "Unassigned",
                        NewValue = ticket.AssignedToUserId,
                        ChangedDate = DateTime.Now
                    });

                    // Enregistrer l'assignation d'équipe dans l'historique si modifiée
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
        }
    }
}