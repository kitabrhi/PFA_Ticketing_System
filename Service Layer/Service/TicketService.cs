using Ticketing_System.Models;
using Ticketing_System.Repository.Interfaces;
public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;

    public TicketService(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    // Méthodes de base CRUD
    public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
    {
        return await _ticketRepository.GetAllAsync();
    }

    public async Task<Ticket> GetTicketByIdAsync(int ticketId)
    {
        var ticket = await _ticketRepository.GetByIdAsync(ticketId);
        if (ticket == null)
        {
            throw new KeyNotFoundException($"Ticket with ID {ticketId} not found");
        }
        return ticket;
    }

    public async Task<Ticket> CreateTicketAsync(Ticket ticket)
    {
        // Validation de base
        if (ticket == null) throw new ArgumentNullException(nameof(ticket));
        if (string.IsNullOrEmpty(ticket.Title)) throw new ArgumentException("Ticket title cannot be empty");
        if (string.IsNullOrEmpty(ticket.Description)) throw new ArgumentException("Ticket description cannot be empty");

        // Valeurs par défaut
        ticket.CreatedDate = DateTime.Now;
        ticket.UpdatedDate = DateTime.Now;
        ticket.Status = TicketStatus.Open;
        if (string.IsNullOrEmpty(ticket.Source)) ticket.Source = "Web";

        // Création du ticket
        return await _ticketRepository.AddAsync(ticket);
    }

    public async Task UpdateTicketAsync(Ticket ticket)
    {
        if (ticket == null) throw new ArgumentNullException(nameof(ticket));

        var existingTicket = await _ticketRepository.GetByIdAsync(ticket.TicketID);
        if (existingTicket == null)
        {
            throw new KeyNotFoundException($"Ticket with ID {ticket.TicketID} not found");
        }

        // Mise à jour de la date de modification
        ticket.UpdatedDate = DateTime.Now;

        // Mise à jour du ticket
        await _ticketRepository.UpdateAsync(ticket);
    }

    public async Task DeleteTicketAsync(int ticketId)
    {
        var ticket = await _ticketRepository.GetByIdAsync(ticketId);
        if (ticket == null)
        {
            throw new KeyNotFoundException($"Ticket with ID {ticketId} not found");
        }

        await _ticketRepository.DeleteAsync(ticket);
    }

    // Filtrage et recherche
    public async Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync(string userId)
    {
        return await _ticketRepository.GetTicketsByUserIdAsync(userId);
    }

    public async Task<IEnumerable<Ticket>> GetTicketsByAssignedUserIdAsync(string userId)
    {
        return await _ticketRepository.GetTicketsByAssignedUserIdAsync(userId);
    }

    public async Task<IEnumerable<Ticket>> GetTicketsByAssignedTeamIdAsync(int teamId)
    {
        return await _ticketRepository.GetTicketsByAssignedTeamIdAsync(teamId);
    }

    public async Task<IEnumerable<Ticket>> GetTicketsByStatusAsync(TicketStatus status)
    {
        return await _ticketRepository.GetTicketsByStatusAsync(status);
    }

    public async Task<IEnumerable<Ticket>> GetTicketsByPriorityAsync(TicketPriority priority)
    {
        return await _ticketRepository.GetTicketsByPriorityAsync(priority);
    }

    public async Task<IEnumerable<Ticket>> GetTicketsByCategoryAsync(TicketCategory category)
    {
        return await _ticketRepository.GetTicketsByCategoryAsync(category);
    }

    public async Task<IEnumerable<Ticket>> SearchTicketsAsync(string searchTerm)
    {
        return await _ticketRepository.SearchTicketsAsync(searchTerm);
    }
}