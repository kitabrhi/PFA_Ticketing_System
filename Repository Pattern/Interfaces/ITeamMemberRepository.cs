using Ticketing_System.Models;

namespace Ticketing_System.Repository.Interfaces
{
    public interface ITeamMemberRepository
    {
        Task<List<TeamMember>> GetAllAsync();
        Task<TeamMember> GetByIdAsync(int id);
        Task<List<TeamMember>> GetMembersByTeamIdAsync(int teamId);
        Task<List<TeamMember>> GetTeamsByUserIdAsync(string userId);
        Task<bool> IsUserInTeamAsync(string userId, int teamId);
        Task<TeamMember> GetMemberByUserAndTeamAsync(string userId, int teamId);
        Task AddAsync(TeamMember member);
        Task UpdateAsync(TeamMember member);
        Task DeleteAsync(int id);
        Task DeleteByUserAndTeamAsync(string userId, int teamId);
        Task<User> GetMemberWithLowestWorkloadAsync(int teamId);
    }
}