using Ticketing_System.Models;

public interface ITeamMemberService
{
    Task<List<TeamMember>> GetAllAsync();
    Task<TeamMember> GetByIdAsync(int id);
    Task AddAsync(TeamMember member);
    Task UpdateAsync(TeamMember member);
    Task DeleteAsync(int id);
}
