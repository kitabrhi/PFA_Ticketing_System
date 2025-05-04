using Ticketing_System.Models;
using Ticketing_System.Repository.Interfaces;
using Ticketing_System.Service_Layer.Service;
public class SupportTeamService : ISupportTeamService
{
    private readonly ISupportTeamRepository _repo;
    public SupportTeamService(ISupportTeamRepository repo) => _repo = repo;

    public Task<List<SupportTeam>> GetAllAsync() => _repo.GetAllAsync();
    public Task<SupportTeam> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
    public Task AddAsync(SupportTeam team) => _repo.AddAsync(team);
    public Task UpdateAsync(SupportTeam team) => _repo.UpdateAsync(team);
    public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    public Task<List<SupportTeam>> GetSupportTeamsAsync() => _repo.GetAllAsync();
}  

