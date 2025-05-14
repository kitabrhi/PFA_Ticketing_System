using Microsoft.Extensions.Logging;
using Ticketing_System.Models;
using Ticketing_System.Repository.Interfaces;
using Ticketing_System.Service_Layer.Interfaces;

namespace Ticketing_System.Service_Layer.Service
{
    public class SupportTeamService : ISupportTeamService
    {
        private readonly ISupportTeamRepository _teamRepository;
        private readonly ITeamMemberRepository _memberRepository;
        private readonly INotificationService _notificationService;
        private readonly ILogger<SupportTeamService> _logger;

        public SupportTeamService(
            ISupportTeamRepository teamRepository,
            ITeamMemberRepository memberRepository,
            INotificationService notificationService,
            ILogger<SupportTeamService> logger)
        {
            _teamRepository = teamRepository;
            _memberRepository = memberRepository;
            _notificationService = notificationService;
            _logger = logger;
        }

        public async Task<List<SupportTeam>> GetAllAsync()
        {
            return await _teamRepository.GetAllAsync();
        }

        public async Task<SupportTeam> GetByIdAsync(int id)
        {
            return await _teamRepository.GetByIdAsync(id);
        }

        public async Task<SupportTeam> GetByIdWithDetailsAsync(int id)
        {
            return await _teamRepository.GetByIdWithDetailsAsync(id);
        }

        public async Task<List<SupportTeam>> GetTeamsByManagerIdAsync(string managerId)
        {
            return await _teamRepository.GetTeamsByManagerIdAsync(managerId);
        }

        public async Task<SupportTeam> CreateTeamAsync(SupportTeam team, List<string> memberIds)
        {
            try
            {
                if (team == null)
                    throw new ArgumentNullException(nameof(team));

                // Ajouter l'équipe
                await _teamRepository.AddAsync(team);

                // Ajouter les membres s'il y en a
                if (memberIds != null && memberIds.Any())
                {
                    foreach (var memberId in memberIds)
                    {
                        var member = new TeamMember
                        {
                            TeamID = team.TeamID,
                            UserId = memberId,
                            JoinDate = DateTime.Now
                        };
                        await _memberRepository.AddAsync(member);
                    }
                }

                // Notification au manager si défini
                if (!string.IsNullOrEmpty(team.ManagerId))
                {
                    await _notificationService.CreateNotificationAsync(
                        team.ManagerId,
                        "Nouvelle équipe",
                        $"Vous avez été désigné manager de l'équipe {team.TeamName}."
                    );
                }

                _logger.LogInformation($"Équipe créée: {team.TeamName} (ID: {team.TeamID})");
                return team;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erreur lors de la création de l'équipe: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateTeamAsync(SupportTeam team, List<string> memberIds)
        {
            try
            {
                if (team == null)
                    throw new ArgumentNullException(nameof(team));

                // Récupérer l'équipe existante
                var existingTeam = await _teamRepository.GetByIdWithDetailsAsync(team.TeamID);
                if (existingTeam == null)
                    throw new InvalidOperationException($"L'équipe avec l'ID {team.TeamID} n'existe pas.");

                // Conserver l'ancien ID du manager pour les notifications
                string oldManagerId = existingTeam.ManagerId;

                // Mettre à jour les propriétés de base
                existingTeam.TeamName = team.TeamName;
                existingTeam.Description = team.Description;
                existingTeam.ManagerId = team.ManagerId;

                await _teamRepository.UpdateAsync(existingTeam);

                // Mettre à jour les membres si la liste est fournie
                if (memberIds != null)
                {
                    // Récupérer les membres actuels
                    var currentMembers = await _memberRepository.GetMembersByTeamIdAsync(team.TeamID);
                    var currentMemberIds = currentMembers.Select(m => m.UserId).ToList();

                    // Déterminer les membres à ajouter et à supprimer
                    var membersToAdd = memberIds.Where(id => !currentMemberIds.Contains(id)).ToList();
                    var membersToRemove = currentMembers.Where(m => !memberIds.Contains(m.UserId)).ToList();

                    // Supprimer les membres qui ne sont plus dans la liste
                    foreach (var member in membersToRemove)
                    {
                        await _memberRepository.DeleteAsync(member.TeamMemberID);

                        // Notification
                        await _notificationService.CreateNotificationAsync(
                            member.UserId,
                            "Retrait d'équipe",
                            $"Vous avez été retiré de l'équipe {team.TeamName}."
                        );
                    }

                    // Ajouter les nouveaux membres
                    foreach (var userId in membersToAdd)
                    {
                        var newMember = new TeamMember
                        {
                            TeamID = team.TeamID,
                            UserId = userId,
                            JoinDate = DateTime.Now
                        };
                        await _memberRepository.AddAsync(newMember);

                        // Notification
                        await _notificationService.CreateNotificationAsync(
                            userId,
                            "Ajout à une équipe",
                            $"Vous avez été ajouté à l'équipe {team.TeamName}."
                        );
                    }
                }

                // Notification au nouveau manager si changé
                if (!string.IsNullOrEmpty(team.ManagerId) && team.ManagerId != oldManagerId)
                {
                    await _notificationService.CreateNotificationAsync(
                        team.ManagerId,
                        "Gestion d'équipe",
                        $"Vous avez été désigné manager de l'équipe {team.TeamName}."
                    );

                    // Notification à l'ancien manager si existant
                    if (!string.IsNullOrEmpty(oldManagerId))
                    {
                        await _notificationService.CreateNotificationAsync(
                            oldManagerId,
                            "Gestion d'équipe",
                            $"Vous n'êtes plus le manager de l'équipe {team.TeamName}."
                        );
                    }
                }

                _logger.LogInformation($"Équipe mise à jour: {team.TeamName} (ID: {team.TeamID})");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erreur lors de la mise à jour de l'équipe (ID: {team.TeamID}): {ex.Message}");
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var team = await _teamRepository.GetByIdWithDetailsAsync(id);
                if (team == null)
                    throw new InvalidOperationException($"L'équipe avec l'ID {id} n'existe pas.");

                // Envoyer des notifications avant la suppression
                if (team.TeamMembers != null && team.TeamMembers.Any())
                {
                    foreach (var member in team.TeamMembers)
                    {
                        await _notificationService.CreateNotificationAsync(
                            member.UserId,
                            "Suppression d'équipe",
                            $"L'équipe {team.TeamName} a été supprimée."
                        );
                    }
                }

                if (!string.IsNullOrEmpty(team.ManagerId))
                {
                    await _notificationService.CreateNotificationAsync(
                        team.ManagerId,
                        "Suppression d'équipe",
                        $"L'équipe {team.TeamName} que vous gériez a été supprimée."
                    );
                }

                await _teamRepository.DeleteAsync(id);
                _logger.LogInformation($"Équipe supprimée: ID {id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erreur lors de la suppression de l'équipe (ID: {id}): {ex.Message}");
                throw;
            }
        }

        public async Task AssignManagerAsync(int teamId, string managerId)
        {
            try
            {
                var team = await _teamRepository.GetByIdAsync(teamId);
                if (team == null)
                    throw new InvalidOperationException($"L'équipe avec l'ID {teamId} n'existe pas.");

                string oldManagerId = team.ManagerId;
                team.ManagerId = managerId;
                await _teamRepository.UpdateAsync(team);

                // Notification au nouveau manager
                if (!string.IsNullOrEmpty(managerId))
                {
                    await _notificationService.CreateNotificationAsync(
                        managerId,
                        "Gestion d'équipe",
                        $"Vous avez été désigné manager de l'équipe {team.TeamName}."
                    );
                }

                // Notification à l'ancien manager si existant
                if (!string.IsNullOrEmpty(oldManagerId) && oldManagerId != managerId)
                {
                    await _notificationService.CreateNotificationAsync(
                        oldManagerId,
                        "Gestion d'équipe",
                        $"Vous n'êtes plus le manager de l'équipe {team.TeamName}."
                    );
                }

                _logger.LogInformation($"Manager de l'équipe {team.TeamName} (ID: {teamId}) modifié: {oldManagerId} -> {managerId}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erreur lors de l'assignation du manager pour l'équipe (ID: {teamId}): {ex.Message}");
                throw;
            }
        }

        public async Task<int> GetTicketCountAsync(int teamId)
        {
            return await _teamRepository.GetTicketCountAsync(teamId);
        }

        public async Task<bool> HasActiveAgentsAsync(int teamId)
        {
            return await _teamRepository.HasActiveAgentsAsync(teamId);
        }
    }
}