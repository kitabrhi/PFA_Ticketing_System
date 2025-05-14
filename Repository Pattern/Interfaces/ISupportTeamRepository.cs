using Ticketing_System.Models;

namespace Ticketing_System.Repository.Interfaces
{
    public interface ISupportTeamRepository
    {
        Task<List<SupportTeam>> GetAllAsync();
        Task<SupportTeam> GetByIdAsync(int id);
        Task<SupportTeam> GetByIdWithDetailsAsync(int id);
        Task<List<SupportTeam>> GetTeamsByManagerIdAsync(string managerId);
        Task AddAsync(SupportTeam team);
        Task UpdateAsync(SupportTeam team);
        Task DeleteAsync(int id);
        Task<int> GetTicketCountAsync(int teamId);
        Task<bool> HasActiveAgentsAsync(int teamId);
    }
}