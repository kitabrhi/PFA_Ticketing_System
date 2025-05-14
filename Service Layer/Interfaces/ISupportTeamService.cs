using Ticketing_System.Models;

namespace Ticketing_System.Service_Layer.Interfaces
{
    public interface ISupportTeamService
    {
        Task<List<SupportTeam>> GetAllAsync();
        Task<SupportTeam> GetByIdAsync(int id);
        Task<SupportTeam> GetByIdWithDetailsAsync(int id);
        Task<List<SupportTeam>> GetTeamsByManagerIdAsync(string managerId);
        Task<SupportTeam> CreateTeamAsync(SupportTeam team, List<string> memberIds);
        Task UpdateTeamAsync(SupportTeam team, List<string> memberIds);
        Task DeleteAsync(int id);
        Task AssignManagerAsync(int teamId, string managerId);
        Task<int> GetTicketCountAsync(int teamId);
        Task<bool> HasActiveAgentsAsync(int teamId);
    }
}