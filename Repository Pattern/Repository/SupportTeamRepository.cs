using Microsoft.EntityFrameworkCore;
using Ticketing_System.Models;
using Ticketing_System.Repository.Interfaces;

namespace Ticketing_System.Repository
{
    public class SupportTeamRepository : ISupportTeamRepository
    {
        private readonly ApplicationDbContext _context;

        public SupportTeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SupportTeam>> GetAllAsync()
        {
            return await _context.SupportTeams
                .Include(t => t.Manager)
                .ToListAsync();
        }

        public async Task<SupportTeam> GetByIdAsync(int id)
        {
            return await _context.SupportTeams
                .Include(t => t.Manager)
                .FirstOrDefaultAsync(t => t.TeamID == id);
        }

        public async Task<SupportTeam> GetByIdWithDetailsAsync(int id)
        {
            return await _context.SupportTeams
                .Include(t => t.Manager)
                .Include(t => t.TeamMembers)
                    .ThenInclude(tm => tm.User)
                .Include(t => t.AssignedTickets)
                .FirstOrDefaultAsync(t => t.TeamID == id);
        }

        public async Task<List<SupportTeam>> GetTeamsByManagerIdAsync(string managerId)
        {
            return await _context.SupportTeams
                .Where(t => t.ManagerId == managerId)
                .Include(t => t.TeamMembers)
                .ToListAsync();
        }

        public async Task AddAsync(SupportTeam team)
        {
            await _context.SupportTeams.AddAsync(team);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SupportTeam team)
        {
            _context.SupportTeams.Update(team);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var team = await GetByIdWithDetailsAsync(id);
            if (team != null)
            {
                // Supprimer les membres de l'équipe
                if (team.TeamMembers != null && team.TeamMembers.Any())
                {
                    _context.TeamMembers.RemoveRange(team.TeamMembers);
                }

                // Mettre à jour les tickets assignés
                if (team.AssignedTickets != null && team.AssignedTickets.Any())
                {
                    foreach (var ticket in team.AssignedTickets)
                    {
                        ticket.AssignedToTeamID = null;
                    }
                }

                // Supprimer l'équipe
                _context.SupportTeams.Remove(team);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> GetTicketCountAsync(int teamId)
        {
            return await _context.Tickets
                .CountAsync(t => t.AssignedToTeamID == teamId);
        }

        public async Task<bool> HasActiveAgentsAsync(int teamId)
        {
            var activeAgentCount = await _context.TeamMembers
                .Where(tm => tm.TeamID == teamId)
                .Include(tm => tm.User)
                .CountAsync(tm => tm.User.IsActive);

            return activeAgentCount > 0;
        }
    }
}