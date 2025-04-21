using Ticketing_System.Models;
using Ticketing_System.Repository.Interfaces;


public interface ITeamMemberRepository
{
    Task<List<TeamMember>> GetAllAsync();
    Task<TeamMember> GetByIdAsync(int id);
    Task AddAsync(TeamMember member);
    Task UpdateAsync(TeamMember member);
    Task DeleteAsync(int id);
}
