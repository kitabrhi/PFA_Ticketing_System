using Ticketing_System.Models;


public interface ITicketService
{
    // Méthodes de base
    Task<IEnumerable<Ticket>> GetAllTicketsAsync();
    Task<Ticket> GetTicketByIdAsync(int ticketId);
    Task<Ticket> CreateTicketAsync(Ticket ticket);
    Task UpdateTicketAsync(Ticket ticket);
    Task DeleteTicketAsync(int ticketId);

    // Filtrage et recherche
    Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync(string userId);
    Task<IEnumerable<Ticket>> GetTicketsByAssignedUserIdAsync(string userId);
    Task<IEnumerable<Ticket>> GetTicketsByAssignedTeamIdAsync(int teamId);
    Task<IEnumerable<Ticket>> GetTicketsByStatusAsync(TicketStatus status);
    Task<IEnumerable<Ticket>> GetTicketsByPriorityAsync(TicketPriority priority);
    Task<IEnumerable<Ticket>> GetTicketsByCategoryAsync(TicketCategory category);
    Task<IEnumerable<Ticket>> SearchTicketsAsync(string searchTerm);
}
