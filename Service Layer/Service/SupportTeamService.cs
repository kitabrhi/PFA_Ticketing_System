using Ticketing_System.Models;
using Microsoft.EntityFrameworkCore;
using Ticketing_System.Repository.Interfaces;
using Ticketing_System.Service_Layer.Service;
using Ticketing_System;
public class SupportTeamService : ISupportTeamService
{
    private readonly ISupportTeamRepository _repo;
        private readonly ApplicationDbContext _context;
    public SupportTeamService(ISupportTeamRepository repo, ApplicationDbContext context){
         {
        _repo = repo;
        _context = context;
    }
    }

    public Task<List<SupportTeam>> GetAllAsync() => _repo.GetAllAsync();
    public Task<SupportTeam> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
    public Task AddAsync(SupportTeam team) => _repo.AddAsync(team);
    public Task UpdateAsync(SupportTeam team) => _repo.UpdateAsync(team);
    public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    public Task<List<SupportTeam>> GetSupportTeamsAsync() => _repo.GetAllAsync();

    public async Task<SupportTeam> CreateSupportTeamAsync(SupportTeam team, List<string> memberIds, List<int> ticketIds)
    {
        // Ajouter les membres à l’équipe
        team.TeamMembers = memberIds.Select(id => new TeamMember
        {
            UserId = id,
            JoinDate = DateTime.Now
        }).ToList();

        // Ajouter l’équipe dans la base
        _context.SupportTeams.Add(team);
        await _context.SaveChangesAsync(); // Pour obtenir l'ID

        // Associer les tickets à l’équipe
        var tickets = await _context.Tickets
            .Where(t => ticketIds.Contains(t.TicketID))
            .ToListAsync();

        foreach (var ticket in tickets)
        {
            ticket.AssignedToTeamID = team.TeamID;
        }

        await _context.SaveChangesAsync();

        return team;
    }
}  

