using Microsoft.EntityFrameworkCore;
using Ticketing_System.Models;
using Ticketing_System.Repository;
using Ticketing_System.Repository.Interfaces;

namespace Ticketing_System.Repository {

public class SupportTeamRepository : ISupportTeamRepository
{
    private readonly ApplicationDbContext _context;
    public SupportTeamRepository(ApplicationDbContext context) => _context = context;

    public async Task<List<SupportTeam>> GetAllAsync() =>
         await _context.SupportTeams.ToListAsync();


    public async Task<SupportTeam> GetByIdAsync(int id) =>
    await _context.SupportTeams
        .Include(t => t.TeamMembers)
        .Include(t => t.AssignedTickets)
        .FirstOrDefaultAsync(t => t.TeamID == id);


    public async Task AddAsync(SupportTeam team)
{
    _context.SupportTeams.Add(team);
    await _context.SaveChangesAsync(); // ✅ CETTE LIGNE EXISTE DÉJÀ
}


    public async Task UpdateAsync(SupportTeam team)
    {
        _context.SupportTeams.Update(team);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
{
    var team = await _context.SupportTeams
        .Include(t => t.TeamMembers)
        .Include(t => t.AssignedTickets)
        .FirstOrDefaultAsync(t => t.TeamID == id);

    if (team != null)
    {
        // Supprimer les membres liés
        _context.TeamMembers.RemoveRange(team.TeamMembers);

        // Détacher les tickets liés
        foreach (var ticket in team.AssignedTickets)
        {
            ticket.AssignedToTeamID = null;
        }

        // Supprimer l'équipe elle-même
        _context.SupportTeams.Remove(team);

        await _context.SaveChangesAsync();
    }
}

}
}