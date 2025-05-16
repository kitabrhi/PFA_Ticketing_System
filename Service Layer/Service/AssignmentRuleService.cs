using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<AssignmentRuleService> _logger;

        public AssignmentRuleService(
            IAssignmentRuleRepository ruleRepository,
            ITicketRepository ticketRepository,
            ITicketHistoryService historyService,
            UserManager<User> userManager,
            ApplicationDbContext context,
            ILogger<AssignmentRuleService> logger)
        {
            _ruleRepository = ruleRepository;
            _ticketRepository = ticketRepository;
            _historyService = historyService;
            _userManager = userManager;
            _context = context;
            _logger = logger;
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
            _logger.LogInformation($"Tentative d'application de règle d'assignation pour le ticket #{ticketId}");

            var ticket = await _ticketRepository.GetByIdAsync(ticketId);
            if (ticket == null)
            {
                throw new KeyNotFoundException($"Ticket with ID {ticketId} not found");
            }

            var matchingRule = await GetMatchingRuleForTicketAsync(ticket);
            if (matchingRule != null)
            {
                _logger.LogInformation($"Règle trouvée pour le ticket #{ticketId}: {matchingRule.RuleName} (ID: {matchingRule.RuleID})");

                // Sauvegarder l'état actuel avant modification
                string oldAssignedUserId = ticket.AssignedToUserId;
                int? oldAssignedTeamId = ticket.AssignedToTeamID;

                // Appliquer la règle
                if (!string.IsNullOrEmpty(matchingRule.AssignToUserID))
                {
                    // Vérifier si l'utilisateur est actif
                    var user = await _userManager.FindByIdAsync(matchingRule.AssignToUserID);
                    if (user != null && user.IsActive)
                    {
                        _logger.LogInformation($"Assignation du ticket #{ticketId} à l'utilisateur {user.Email} (ID: {user.Id})");

                        // Si la règle spécifie un utilisateur, assigner directement
                        ticket.AssignedToUserId = matchingRule.AssignToUserID;

                        // Au lieu de mettre AssignedToTeamID à null, trouver l'équipe de l'agent
                        var teamMember = await _context.TeamMembers
                            .AsNoTracking()
                            .FirstOrDefaultAsync(tm => tm.UserId == matchingRule.AssignToUserID);

                        if (teamMember != null)
                        {
                            ticket.AssignedToTeamID = teamMember.TeamID;
                            _logger.LogInformation($"Ticket également assigné à l'équipe ID: {teamMember.TeamID}");
                        }
                        else
                        {
                            ticket.AssignedToTeamID = null;
                        }
                    }
                    else
                    {
                        _logger.LogWarning($"L'utilisateur spécifié dans la règle (ID: {matchingRule.AssignToUserID}) n'existe pas ou est inactif");
                        throw new InvalidOperationException("The specified user in the rule doesn't exist or is inactive");
                    }
                }
                else if (matchingRule.AssignToTeamID.HasValue)
                {
                    // Si la règle spécifie une équipe, assigner l'équipe
                    ticket.AssignedToTeamID = matchingRule.AssignToTeamID;
                    _logger.LogInformation($"Assignation du ticket #{ticketId} à l'équipe ID: {matchingRule.AssignToTeamID}");

                    // Rechercher l'agent le moins chargé dans cette équipe et l'assigner également
                    await AssignToLeastBusyAgentInTeam(ticket, matchingRule.AssignToTeamID.Value);
                }

                ticket.UpdatedDate = DateTime.Now;
                await _ticketRepository.UpdateAsync(ticket);
                _logger.LogInformation($"Ticket #{ticketId} mis à jour avec succès");

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
            else
            {
                _logger.LogWarning($"Aucune règle d'assignation trouvée pour le ticket #{ticketId}");
                throw new InvalidOperationException("No matching assignment rule found for this ticket");
            }
        }

        private async Task AssignToLeastBusyAgentInTeam(Ticket ticket, int teamId)
        {
            _logger.LogInformation($"Recherche de l'agent le moins occupé dans l'équipe ID: {teamId}");

            // Obtenir tous les membres de l'équipe
            var teamMembers = await _context.TeamMembers
                .AsNoTracking()
                .Where(tm => tm.TeamID == teamId)
                .Select(tm => tm.UserId)
                .ToListAsync();

            if (teamMembers.Any())
            {
                _logger.LogInformation($"Membres trouvés dans l'équipe: {teamMembers.Count}");

                // Filtrer pour ne garder que les agents de support actifs
                var supportAgents = new List<User>();
                foreach (var userId in teamMembers)
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null && user.IsActive && await _userManager.IsInRoleAsync(user, "SupportAgent"))
                    {
                        supportAgents.Add(user);
                    }
                }

                _logger.LogInformation($"Agents de support actifs dans l'équipe: {supportAgents.Count}");

                if (supportAgents.Any())
                {
                    // Récupérer tous les tickets actifs pour ces agents en une seule requête
                    var agentIds = supportAgents.Select(a => a.Id).ToList();

                    var activeTickets = await _context.Tickets
                        .AsNoTracking()
                        .Where(t => (t.Status == TicketStatus.New ||
                                   t.Status == TicketStatus.Open ||
                                   t.Status == TicketStatus.InProgress) &&
                                   agentIds.Contains(t.AssignedToUserId))
                        .Select(t => new { t.TicketID, t.AssignedToUserId })
                        .ToListAsync();

                    // Calculer la charge de travail pour chaque agent
                    var workloads = new Dictionary<string, int>();
                    foreach (var agent in supportAgents)
                    {
                        workloads[agent.Id] = activeTickets.Count(t => t.AssignedToUserId == agent.Id);
                        _logger.LogInformation($"Agent: {agent.FirstName} {agent.LastName} (ID: {agent.Id}) - Charge: {workloads[agent.Id]} tickets");
                    }

                    // Trouver les agents avec la charge la plus faible
                    if (workloads.Any())
                    {
                        var minValue = workloads.Min(w => w.Value);
                        var leastBusyAgents = workloads.Where(w => w.Value == minValue).ToList();

                        _logger.LogInformation($"Agents les moins occupés (charge: {minValue}): {leastBusyAgents.Count}");

                        // En cas d'égalité, choisir au hasard
                        int randomIndex = new Random().Next(leastBusyAgents.Count);
                        var selectedAgent = leastBusyAgents[randomIndex];

                        var agent = supportAgents.First(a => a.Id == selectedAgent.Key);
                        _logger.LogInformation($"Agent sélectionné: {agent.FirstName} {agent.LastName} (ID: {agent.Id})");

                        // Assigner à l'agent sélectionné
                        ticket.AssignedToUserId = selectedAgent.Key;
                        ticket.AssignedToTeamID = teamId;
                    }
                    else
                    {
                        _logger.LogWarning("Aucun agent avec charge de travail calculable");

                        // Sélection aléatoire d'un agent
                        int randomIndex = new Random().Next(supportAgents.Count);
                        var randomAgent = supportAgents[randomIndex];

                        _logger.LogInformation($"Sélection aléatoire de l'agent: {randomAgent.FirstName} {randomAgent.LastName} (ID: {randomAgent.Id})");

                        ticket.AssignedToUserId = randomAgent.Id;
                        ticket.AssignedToTeamID = teamId;
                    }
                }
                else
                {
                    _logger.LogWarning($"Aucun agent de support actif trouvé dans l'équipe {teamId}");
                }
            }
            else
            {
                _logger.LogWarning($"Aucun membre trouvé dans l'équipe {teamId}");
            }
        }

        public async Task AutoAssignTicketAsync(Ticket ticket)
        {
            if (ticket == null) throw new ArgumentNullException(nameof(ticket));

            _logger.LogInformation($"Auto-assignation du ticket #{ticket.TicketID}");

            var matchingRule = await GetMatchingRuleForTicketAsync(ticket);
            if (matchingRule != null)
            {
                _logger.LogInformation($"Règle trouvée pour le ticket #{ticket.TicketID}: {matchingRule.RuleName}");

                if (!string.IsNullOrEmpty(matchingRule.AssignToUserID))
                {
                    // Vérifier si l'utilisateur est actif
                    var user = await _userManager.FindByIdAsync(matchingRule.AssignToUserID);
                    if (user != null && user.IsActive)
                    {
                        _logger.LogInformation($"Assignation du ticket #{ticket.TicketID} à l'utilisateur {user.Email}");

                        // Si la règle spécifie un utilisateur, assigner directement
                        ticket.AssignedToUserId = matchingRule.AssignToUserID;

                        // Au lieu de mettre AssignedToTeamID à null, trouver l'équipe de l'agent
                        var teamMember = await _context.TeamMembers
                            .AsNoTracking()
                            .FirstOrDefaultAsync(tm => tm.UserId == matchingRule.AssignToUserID);

                        if (teamMember != null)
                        {
                            ticket.AssignedToTeamID = teamMember.TeamID;
                            _logger.LogInformation($"Ticket également assigné à l'équipe ID: {teamMember.TeamID}");
                        }
                        else
                        {
                            ticket.AssignedToTeamID = null;
                        }
                    }
                    else
                    {
                        _logger.LogWarning($"L'utilisateur spécifié dans la règle (ID: {matchingRule.AssignToUserID}) n'existe pas ou est inactif");
                    }
                }
                else if (matchingRule.AssignToTeamID.HasValue)
                {
                    // Si la règle spécifie une équipe, assigner l'équipe
                    ticket.AssignedToTeamID = matchingRule.AssignToTeamID;
                    _logger.LogInformation($"Assignation du ticket #{ticket.TicketID} à l'équipe ID: {matchingRule.AssignToTeamID}");

                    // Rechercher l'agent le moins chargé dans cette équipe
                    await AssignToLeastBusyAgentInTeam(ticket, matchingRule.AssignToTeamID.Value);
                }
            }
            else
            {
                _logger.LogWarning($"Aucune règle d'assignation trouvée pour le ticket #{ticket.TicketID}");
            }
        }

        public async Task AssignTicketToLeastBusyAgentAsync(int ticketId)
        {
            _logger.LogInformation($"Début de l'assignation au moins occupé pour le ticket #{ticketId}");

            // Utiliser AsNoTracking pour éviter les problèmes de cache
            _context.ChangeTracker.Clear();

            var ticket = await _ticketRepository.GetByIdAsync(ticketId);
            if (ticket == null)
            {
                throw new KeyNotFoundException($"Ticket with ID {ticketId} not found");
            }

            // Si le ticket est déjà assigné à un agent, ne rien faire
            if (!string.IsNullOrEmpty(ticket.AssignedToUserId))
            {
                _logger.LogInformation($"Ticket #{ticketId} déjà assigné à {ticket.AssignedToUserId}");
                return;
            }

            string oldAssignedUserId = ticket.AssignedToUserId;
            int? oldAssignedTeamId = ticket.AssignedToTeamID;

            // Récupérer tous les agents de support actifs
            var supportAgents = (await _userManager.GetUsersInRoleAsync("SupportAgent"))
                .Where(a => a.IsActive)
                .ToList();

            // Si aucun agent de support, essayer avec les administrateurs
            if (!supportAgents.Any())
            {
                _logger.LogWarning("Aucun agent de support actif trouvé, tentative avec les administrateurs");
                var adminUsers = (await _userManager.GetUsersInRoleAsync("Admin"))
                    .Where(a => a.IsActive)
                    .ToList();

                supportAgents = adminUsers;
            }

            if (!supportAgents.Any())
            {
                _logger.LogError("Aucun agent ni administrateur actif disponible pour l'assignation");
                return;
            }

            _logger.LogInformation($"Agents disponibles pour l'assignation: {supportAgents.Count}");

            // Récupérer tous les tickets actifs en une seule requête
            var allActiveTickets = await _context.Tickets
                .AsNoTracking() // Important pour éviter le cache
                .Where(t => (t.Status == TicketStatus.New ||
                           t.Status == TicketStatus.Open ||
                           t.Status == TicketStatus.InProgress) &&
                           !string.IsNullOrEmpty(t.AssignedToUserId))
                .Select(t => new { t.TicketID, t.AssignedToUserId })
                .ToListAsync();

            // Calculer manuellement la charge de travail de chaque agent
            var workloads = new Dictionary<string, int>();

            // Initialiser tous les agents avec 0 ticket
            foreach (var agent in supportAgents)
            {
                workloads[agent.Id] = 0;
            }

            // Compter les tickets actifs pour chaque agent
            foreach (var activeTicket in allActiveTickets)
            {
                if (!string.IsNullOrEmpty(activeTicket.AssignedToUserId) &&
                    workloads.ContainsKey(activeTicket.AssignedToUserId))
                {
                    workloads[activeTicket.AssignedToUserId]++;
                }
            }

            // Journaliser la charge de travail de chaque agent
            _logger.LogInformation("Répartition actuelle de la charge de travail:");
            foreach (var agent in supportAgents)
            {
                int ticketCount = workloads.ContainsKey(agent.Id) ? workloads[agent.Id] : 0;
                _logger.LogInformation($"  - {agent.FirstName} {agent.LastName} (ID: {agent.Id}): {ticketCount} tickets actifs");
            }

            // Sélectionner les agents ayant le moins de tickets
            var minWorkload = workloads.Values.Min();
            var leastBusyAgents = workloads
                .Where(w => w.Value == minWorkload)
                .ToList();

            _logger.LogInformation($"Nombre d'agents avec la charge minimale ({minWorkload} tickets): {leastBusyAgents.Count}");

            if (!leastBusyAgents.Any())
            {
                _logger.LogError("Impossible de déterminer l'agent le moins occupé");
                return;
            }

            // En cas d'égalité, sélectionner aléatoirement
            var random = new Random();
            int randomIndex = random.Next(leastBusyAgents.Count);
            var selectedAgent = leastBusyAgents[randomIndex];
            var leastBusyAgentId = selectedAgent.Key;

            var leastBusyAgent = supportAgents.FirstOrDefault(a => a.Id == leastBusyAgentId);
            if (leastBusyAgent == null)
            {
                _logger.LogError($"Agent {leastBusyAgentId} non trouvé dans la liste des agents disponibles");
                return;
            }

            _logger.LogInformation($"Agent le moins occupé sélectionné: {leastBusyAgent.FirstName} {leastBusyAgent.LastName} (ID: {leastBusyAgentId}) avec {selectedAgent.Value} tickets");

            // Assigner le ticket à l'agent sélectionné
            ticket.AssignedToUserId = leastBusyAgentId;

            // Chercher l'équipe de l'agent
            var teamMember = await _context.TeamMembers
                .AsNoTracking()
                .FirstOrDefaultAsync(tm => tm.UserId == leastBusyAgentId);

            if (teamMember != null)
            {
                ticket.AssignedToTeamID = teamMember.TeamID;
                _logger.LogInformation($"Ticket également assigné à l'équipe ID: {teamMember.TeamID}");
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
                NewValue = $"{leastBusyAgentId} ({leastBusyAgent.FirstName} {leastBusyAgent.LastName})",
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

            _logger.LogInformation($"✅ Ticket #{ticketId} assigné avec succès à l'agent {leastBusyAgent.FirstName} {leastBusyAgent.LastName}");
        }

        public async Task AssignTicketAutomaticallyAsync(int ticketId)
        {
            _logger.LogInformation($"Début de l'assignation automatique pour le ticket #{ticketId}");

            try
            {
                // 1. D'abord, essayer d'appliquer une règle d'assignation
                bool ruleApplied = false;
                try
                {
                    await ApplyRuleToTicketAsync(ticketId);
                    ruleApplied = true;
                    _logger.LogInformation($"Règle d'assignation appliquée au ticket #{ticketId}");
                }
                catch (Exception ex)
                {
                    _logger.LogWarning($"Aucune règle d'assignation applicable: {ex.Message}");
                }

                // 2. Vérifier si le ticket a été assigné correctement
                var ticket = await _ticketRepository.GetByIdAsync(ticketId);

                // 3. Si le ticket n'est pas assigné, utiliser la méthode d'assignation à l'agent le moins occupé
                if (string.IsNullOrEmpty(ticket.AssignedToUserId))
                {
                    _logger.LogInformation($"Ticket #{ticketId} non assigné par règle, tentative d'assignation au moins occupé");
                    await AssignTicketToLeastBusyAgentAsync(ticketId);
                }

                // 4. Vérification finale
                var finalTicket = await _ticketRepository.GetByIdAsync(ticketId);
                if (string.IsNullOrEmpty(finalTicket.AssignedToUserId))
                {
                    _logger.LogWarning($"⚠️ ATTENTION: Le ticket #{ticketId} n'a pas pu être assigné automatiquement");
                }
                else
                {
                    _logger.LogInformation($"✅ Ticket #{ticketId} assigné avec succès à l'agent {finalTicket.AssignedToUserId}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erreur critique lors de l'assignation automatique du ticket #{ticketId}");
                throw; // Permet au contrôleur de gérer l'exception
            }
        }
    }
}