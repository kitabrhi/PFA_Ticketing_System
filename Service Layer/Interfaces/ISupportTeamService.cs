using Ticketing_System.Models;
using Ticketing_System.Service_Layer.Interfaces;

public interface ISupportTeamService
{
    Task<List<SupportTeam>> GetAllAsync();
    Task<SupportTeam> GetByIdAsync(int id);
    Task AddAsync(SupportTeam team);
    Task UpdateAsync(SupportTeam team);
    Task DeleteAsync(int id);

    Task<List<SupportTeam>> GetSupportTeamsAsync();
Task<SupportTeam> CreateSupportTeamAsync(SupportTeam team, List<string> memberIds, List<int> ticketIds);

}
