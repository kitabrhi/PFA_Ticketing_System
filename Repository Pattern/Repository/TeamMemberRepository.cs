using Microsoft.EntityFrameworkCore;
using Ticketing_System.Models;
using Ticketing_System.Repository.Interfaces;

namespace Ticketing_System.Repository
{
    public class TeamMemberRepository : ITeamMemberRepository
    {
        private readonly ApplicationDbContext _context;

        public TeamMemberRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TeamMember>> GetAllAsync()
        {
            return await _context.TeamMembers
                .Include(tm => tm.User)
                .Include(tm => tm.Team)
                .ToListAsync();
        }

        public async Task<TeamMember> GetByIdAsync(int id)
        {
            return await _context.TeamMembers
                .Include(tm => tm.User)
                .Include(tm => tm.Team)
                .FirstOrDefaultAsync(tm => tm.TeamMemberID == id);
        }

        public async Task<List<TeamMember>> GetMembersByTeamIdAsync(int teamId)
        {
            return await _context.TeamMembers
                .Where(tm => tm.TeamID == teamId)
                .Include(tm => tm.User)
                .ToListAsync();
        }

        public async Task<List<TeamMember>> GetTeamsByUserIdAsync(string userId)
        {
            return await _context.TeamMembers
                .Where(tm => tm.UserId == userId)
                .Include(tm => tm.Team)
                .ToListAsync();
        }

        public async Task<bool> IsUserInTeamAsync(string userId, int teamId)
        {
            return await _context.TeamMembers
                .AnyAsync(tm => tm.UserId == userId && tm.TeamID == teamId);
        }

        public async Task<TeamMember> GetMemberByUserAndTeamAsync(string userId, int teamId)
        {
            return await _context.TeamMembers
                .FirstOrDefaultAsync(tm => tm.UserId == userId && tm.TeamID == teamId);
        }

        public async Task AddAsync(TeamMember member)
        {
            await _context.TeamMembers.AddAsync(member);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TeamMember member)
        {
            _context.TeamMembers.Update(member);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var member = await _context.TeamMembers.FindAsync(id);
            if (member != null)
            {
                _context.TeamMembers.Remove(member);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteByUserAndTeamAsync(string userId, int teamId)
        {
            var member = await GetMemberByUserAndTeamAsync(userId, teamId);
            if (member != null)
            {
                _context.TeamMembers.Remove(member);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User> GetMemberWithLowestWorkloadAsync(int teamId)
        {
            // Récupérer tous les membres de l'équipe avec leurs utilisateurs
            var members = await GetMembersByTeamIdAsync(teamId);
            if (!members.Any())
                return null;

            // Créer un dictionnaire userId -> nombre de tickets
            var userTicketCounts = new Dictionary<string, int>();

            foreach (var member in members)
            {
                // Compter uniquement les tickets ouverts et en cours pour chaque utilisateur
                var ticketCount = await _context.Tickets
                    .CountAsync(t => t.AssignedToUserId == member.UserId &&
                                    (t.Status == TicketStatus.Open ||
                                     t.Status == TicketStatus.InProgress));

                userTicketCounts[member.UserId] = ticketCount;
            }

            // Trouver l'ID de l'utilisateur avec le moins de tickets
            var minWorkloadUserId = userTicketCounts.OrderBy(kv => kv.Value).FirstOrDefault().Key;
            if (string.IsNullOrEmpty(minWorkloadUserId))
                return null;

            // Retourner l'utilisateur ayant le moins de tickets
            return members.FirstOrDefault(m => m.UserId == minWorkloadUserId)?.User;
        }
    }
}