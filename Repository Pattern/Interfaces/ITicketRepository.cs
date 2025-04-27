using Ticketing_System.Models;

namespace Ticketing_System.Repository.Interfaces;

public interface ITicketRepository : IRepository<Ticket>
{
    Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync(string userId);
    Task<IEnumerable<Ticket>> GetTicketsByAssignedUserIdAsync(string userId);
    Task<IEnumerable<Ticket>> GetTicketsByAssignedTeamIdAsync(int teamId);
    Task<IEnumerable<Ticket>> GetTicketsByStatusAsync(TicketStatus status);
    Task<IEnumerable<Ticket>> GetTicketsByPriorityAsync(TicketPriority priority);
    Task<IEnumerable<Ticket>> GetTicketsByCategoryAsync(TicketCategory category);
    Task<IEnumerable<Ticket>> SearchTicketsAsync(string searchTerm);
    
    Task<int> GetTicketCountByStatusAsync(TicketStatus status);


        Task<IEnumerable<Ticket>> GetAllAsync();

        IQueryable<Ticket> Query();


}