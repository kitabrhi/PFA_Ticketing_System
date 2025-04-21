using Microsoft.EntityFrameworkCore;
using Ticketing_System;
using Ticketing_System.Models;
using Ticketing_System.Repository;

public class TeamMemberRepository : ITeamMemberRepository
{
    private readonly ApplicationDbContext _context;
    public TeamMemberRepository(ApplicationDbContext context) => _context = context;

    public async Task<List<TeamMember>> GetAllAsync()
{
    return await _context.TeamMembers
        .Include(tm => tm.User)
        .Include(tm => tm.Team)
        .ToListAsync();
}


    public async Task<TeamMember> GetByIdAsync(int id) =>
        await _context.TeamMembers.Include(tm => tm.User).Include(tm => tm.Team).FirstOrDefaultAsync(tm => tm.TeamMemberID == id);

    public async Task AddAsync(TeamMember member)
    {
        _context.TeamMembers.Add(member);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TeamMember member)
    {
        _context.TeamMembers.Update(member);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var member = await GetByIdAsync(id);
        if (member != null)
        {
            _context.TeamMembers.Remove(member);
            await _context.SaveChangesAsync();
        }
    }

    

}
