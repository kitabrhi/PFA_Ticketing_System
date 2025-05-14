using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Ticketing_System.Models;
using Ticketing_System.Repository.Interfaces;
using Ticketing_System.Service_Layer.Interfaces;

namespace Ticketing_System.Service_Layer.Service
{
    public class TeamMemberService : ITeamMemberService
    {
        private readonly ITeamMemberRepository _memberRepository;
        private readonly ISupportTeamRepository _teamRepository;
        private readonly UserManager<User> _userManager;
        private readonly INotificationService _notificationService;
        private readonly ILogger<TeamMemberService> _logger;

        public TeamMemberService(
            ITeamMemberRepository memberRepository,
            ISupportTeamRepository teamRepository,
            UserManager<User> userManager,
            INotificationService notificationService,
            ILogger<TeamMemberService> logger)
        {
            _memberRepository = memberRepository;
            _teamRepository = teamRepository;
            _userManager = userManager;
            _notificationService = notificationService;
            _logger = logger;
        }

        public async Task<List<TeamMember>> GetAllAsync()
        {
            return await _memberRepository.GetAllAsync();
        }

        public async Task<TeamMember> GetByIdAsync(int id)
        {
            return await _memberRepository.GetByIdAsync(id);
        }

        public async Task<List<TeamMember>> GetMembersByTeamIdAsync(int teamId)
        {
            return await _memberRepository.GetMembersByTeamIdAsync(teamId);
        }

        public async Task<List<TeamMember>> GetTeamsByUserIdAsync(string userId)
        {
            return await _memberRepository.GetTeamsByUserIdAsync(userId);
        }

        public async Task<bool> IsUserInTeamAsync(string userId, int teamId)
        {
            return await _memberRepository.IsUserInTeamAsync(userId, teamId);
        }

        public async Task AddAsync(TeamMember member)
        {
            try
            {
                if (member == null)
                    throw new ArgumentNullException(nameof(member));

                // Vérifier si l'utilisateur est déjà membre de l'équipe  
                var isAlreadyMember = await _memberRepository.IsUserInTeamAsync(member.UserId, member.TeamID);
                if (isAlreadyMember)
                {
                    var existingUser = await _userManager.FindByIdAsync(member.UserId);
                    var existingteam = await _teamRepository.GetByIdAsync(member.TeamID);
                    throw new InvalidOperationException(
                        $"L'utilisateur {existingUser?.FirstName} {existingUser?.LastName} est déjà membre de l'équipe {existingteam?.TeamName}."
                    );
                }

                // Définir la date d'adhésion si non définie  
                if (member.JoinDate == default)
                {
                    member.JoinDate = DateTime.Now;
                }

                await _memberRepository.AddAsync(member);

                // Ajouter le rôle SupportAgent si l'utilisateur ne l'a pas déjà  
                var newUser = await _userManager.FindByIdAsync(member.UserId);
                if (newUser != null && !await _userManager.IsInRoleAsync(newUser, "SupportAgent"))
                {
                    await _userManager.AddToRoleAsync(newUser, "SupportAgent");
                    _logger.LogInformation($"Rôle SupportAgent ajouté à l'utilisateur {newUser.FirstName} {newUser.LastName} (ID: {newUser.Id})");
                }

                // Envoyer une notification  
                var team = await _teamRepository.GetByIdAsync(member.TeamID);
                if (team != null)
                {
                    await _notificationService.CreateNotificationAsync(
                        member.UserId,
                        "Ajout à une équipe",
                        $"Vous avez été ajouté à l'équipe {team.TeamName}."
                    );

                    // Notification au manager de l'équipe si défini  
                    if (!string.IsNullOrEmpty(team.ManagerId))
                    {
                        await _notificationService.CreateNotificationAsync(
                            team.ManagerId,
                            "Nouveau membre dans votre équipe",
                            $"Un nouveau membre a été ajouté à votre équipe {team.TeamName}."
                        );
                    }
                }

                _logger.LogInformation($"Membre ajouté à l'équipe (ID: {member.TeamID}): {member.UserId}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erreur lors de l'ajout du membre à l'équipe: {ex.Message}");
                throw;
            }
        }

        public async Task AddMemberToTeamAsync(string userId, int teamId)
        {
            try
            {
                // Vérifier si l'utilisateur existe
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                    throw new InvalidOperationException($"L'utilisateur avec l'ID {userId} n'existe pas.");

                // Vérifier si l'équipe existe
                var team = await _teamRepository.GetByIdAsync(teamId);
                if (team == null)
                    throw new InvalidOperationException($"L'équipe avec l'ID {teamId} n'existe pas.");

                // Vérifier si l'utilisateur est déjà membre de l'équipe
                var isAlreadyMember = await _memberRepository.IsUserInTeamAsync(userId, teamId);
                if (isAlreadyMember)
                    throw new InvalidOperationException($"L'utilisateur {user.FirstName} {user.LastName} est déjà membre de cette équipe.");

                // Créer et ajouter le membre
                var member = new TeamMember
                {
                    UserId = userId,
                    TeamID = teamId,
                    JoinDate = DateTime.Now
                };

                await _memberRepository.AddAsync(member);

                // Ajouter le rôle SupportAgent si l'utilisateur ne l'a pas déjà
                if (!await _userManager.IsInRoleAsync(user, "SupportAgent"))
                {
                    await _userManager.AddToRoleAsync(user, "SupportAgent");
                    _logger.LogInformation($"Rôle SupportAgent ajouté à l'utilisateur {user.FirstName} {user.LastName} (ID: {user.Id})");
                }

                // Envoyer des notifications
                await _notificationService.CreateNotificationAsync(
                    userId,
                    "Ajout à une équipe",
                    $"Vous avez été ajouté à l'équipe {team.TeamName}."
                );

                if (!string.IsNullOrEmpty(team.ManagerId))
                {
                    await _notificationService.CreateNotificationAsync(
                        team.ManagerId,
                        "Nouveau membre dans votre équipe",
                        $"{user.FirstName} {user.LastName} a été ajouté à votre équipe {team.TeamName}."
                    );
                }

                _logger.LogInformation($"Utilisateur {user.FirstName} {user.LastName} (ID: {userId}) ajouté à l'équipe {team.TeamName} (ID: {teamId})");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erreur lors de l'ajout de l'utilisateur (ID: {userId}) à l'équipe (ID: {teamId}): {ex.Message}");
                throw;
            }
        }

        public async Task RemoveMemberFromTeamAsync(string userId, int teamId)
        {
            try
            {
                // Vérifier si le membre existe
                var member = await _memberRepository.GetMemberByUserAndTeamAsync(userId, teamId);
                if (member == null)
                    throw new InvalidOperationException($"L'utilisateur n'est pas membre de cette équipe.");

                // Récupérer les informations de l'utilisateur et de l'équipe pour les notifications
                var user = await _userManager.FindByIdAsync(userId);
                var team = await _teamRepository.GetByIdAsync(teamId);

                // Supprimer le membre
                await _memberRepository.DeleteAsync(member.TeamMemberID);

                // Vérifier si l'utilisateur est encore membre d'autres équipes
                var userTeams = await _memberRepository.GetTeamsByUserIdAsync(userId);
                if (!userTeams.Any())
                {
                    // Si l'utilisateur n'est plus membre d'aucune équipe, retirer le rôle SupportAgent
                    if (user != null && await _userManager.IsInRoleAsync(user, "SupportAgent"))
                    {
                        await _userManager.RemoveFromRoleAsync(user, "SupportAgent");
                        _logger.LogInformation($"Rôle SupportAgent retiré de l'utilisateur {user.FirstName} {user.LastName} (ID: {userId})");
                    }
                }

                // Envoyer des notifications
                if (user != null && team != null)
                {
                    await _notificationService.CreateNotificationAsync(
                        userId,
                        "Retrait d'équipe",
                        $"Vous avez été retiré de l'équipe {team.TeamName}."
                    );

                    if (!string.IsNullOrEmpty(team.ManagerId))
                    {
                        await _notificationService.CreateNotificationAsync(
                            team.ManagerId,
                            "Membre retiré de votre équipe",
                            $"{user.FirstName} {user.LastName} a été retiré de votre équipe {team.TeamName}."
                        );
                    }
                }

                _logger.LogInformation($"Utilisateur (ID: {userId}) retiré de l'équipe (ID: {teamId})");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erreur lors du retrait de l'utilisateur (ID: {userId}) de l'équipe (ID: {teamId}): {ex.Message}");
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var member = await _memberRepository.GetByIdAsync(id);
                if (member == null)
                    throw new InvalidOperationException($"Le membre d'équipe avec l'ID {id} n'existe pas.");

                // Récupérer les informations pour les notifications
                var user = await _userManager.FindByIdAsync(member.UserId);
                var team = await _teamRepository.GetByIdAsync(member.TeamID);

                await _memberRepository.DeleteAsync(id);

                // Vérifier si l'utilisateur est encore membre d'autres équipes
                var userTeams = await _memberRepository.GetTeamsByUserIdAsync(member.UserId);
                if (!userTeams.Any())
                {
                    // Si l'utilisateur n'est plus membre d'aucune équipe, retirer le rôle SupportAgent
                    if (user != null && await _userManager.IsInRoleAsync(user, "SupportAgent"))
                    {
                        await _userManager.RemoveFromRoleAsync(user, "SupportAgent");
                        _logger.LogInformation($"Rôle SupportAgent retiré de l'utilisateur {user.FirstName} {user.LastName} (ID: {member.UserId})");
                    }
                }

                // Envoyer des notifications
                if (user != null && team != null)
                {
                    await _notificationService.CreateNotificationAsync(
                        member.UserId,
                        "Retrait d'équipe",
                        $"Vous avez été retiré de l'équipe {team.TeamName}."
                    );

                    if (!string.IsNullOrEmpty(team.ManagerId))
                    {
                        await _notificationService.CreateNotificationAsync(
                            team.ManagerId,
                            "Membre retiré de votre équipe",
                            $"{user.FirstName} {user.LastName} a été retiré de votre équipe {team.TeamName}."
                        );
                    }
                }

                _logger.LogInformation($"Membre d'équipe supprimé: ID {id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erreur lors de la suppression du membre d'équipe (ID: {id}): {ex.Message}");
                throw;
            }
        }

        public async Task<User> CreateAgentAndAddToTeamAsync(string firstName, string lastName, string email, string password, int teamId)
        {
            try
            {
                // Vérifier si l'email existe déjà
                var existingUser = await _userManager.FindByEmailAsync(email);
                if (existingUser != null)
                {
                    throw new InvalidOperationException($"Un utilisateur avec l'email {email} existe déjà.");
                }

                // Vérifier si l'équipe existe
                var team = await _teamRepository.GetByIdAsync(teamId);
                if (team == null)
                {
                    throw new InvalidOperationException($"L'équipe avec l'ID {teamId} n'existe pas.");
                }

                // Créer le nouvel utilisateur
                var user = new User
                {
                    UserName = email,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };

                var result = await _userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    throw new InvalidOperationException($"Échec de la création de l'utilisateur: {errors}");
                }

                // Ajouter le rôle SupportAgent
                await _userManager.AddToRoleAsync(user, "SupportAgent");

                // Ajouter l'utilisateur à l'équipe
                var member = new TeamMember
                {
                    UserId = user.Id,
                    TeamID = teamId,
                    JoinDate = DateTime.Now
                };

                await _memberRepository.AddAsync(member);

                // Envoyer des notifications
                await _notificationService.CreateNotificationAsync(
                    user.Id,
                    "Bienvenue",
                    $"Bienvenue dans l'équipe {team.TeamName}. Votre compte a été créé avec succès."
                );

                if (!string.IsNullOrEmpty(team.ManagerId))
                {
                    await _notificationService.CreateNotificationAsync(
                        team.ManagerId,
                        "Nouvel agent dans votre équipe",
                        $"Un nouvel agent, {firstName} {lastName}, a été créé et ajouté à votre équipe {team.TeamName}."
                    );
                }

                _logger.LogInformation($"Nouvel agent créé et ajouté à l'équipe: {firstName} {lastName} (ID: {user.Id}) -> Équipe ID: {teamId}");
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erreur lors de la création de l'agent et de son ajout à l'équipe: {ex.Message}");
                throw;
            }
        }

        public async Task<User> GetAgentForTicketAssignmentAsync(int teamId)
        {
            try
            {
                return await _memberRepository.GetMemberWithLowestWorkloadAsync(teamId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erreur lors de la recherche d'un agent pour l'assignation de ticket à l'équipe (ID: {teamId}): {ex.Message}");
                throw;
            }
        }
    }
}