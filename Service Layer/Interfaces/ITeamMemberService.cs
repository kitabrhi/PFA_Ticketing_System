using Ticketing_System.Models;

namespace Ticketing_System.Service_Layer.Interfaces
{
    public interface ITeamMemberService
    {
        Task<List<TeamMember>> GetAllAsync();
        Task<TeamMember> GetByIdAsync(int id);
        Task<List<TeamMember>> GetMembersByTeamIdAsync(int teamId);
        Task<List<TeamMember>> GetTeamsByUserIdAsync(string userId);
        Task<bool> IsUserInTeamAsync(string userId, int teamId);
        Task AddAsync(TeamMember member);
        Task AddMemberToTeamAsync(string userId, int teamId);
        Task RemoveMemberFromTeamAsync(string userId, int teamId);
        Task DeleteAsync(int id);
        Task<User> CreateAgentAndAddToTeamAsync(string firstName, string lastName, string email, string password, int teamId);
        Task<User> GetAgentForTicketAssignmentAsync(int teamId);
    }
}