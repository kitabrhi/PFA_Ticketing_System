using Ticketing_System.Models;
using Ticketing_System.Repository.Interfaces;
using Ticketing_System.Service_Layer.Interfaces;
public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;
    private readonly ITicketHistoryService _historyService;


    public TicketService(ITicketRepository ticketRepository,ITicketHistoryService historyService)
    {
        _ticketRepository = ticketRepository;
        _historyService = historyService;
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
    public async Task<Ticket> ChangeTicketStatusAsync(int ticketId, TicketStatus newStatus, string userId)
    {
        var ticket = await _ticketRepository.GetByIdAsync(ticketId);
        if (ticket == null)
        {
            throw new KeyNotFoundException($"Ticket with ID {ticketId} not found");
        }

        var oldStatus = ticket.Status;

        // Mise à jour du statut
        ticket.Status = newStatus;
        ticket.UpdatedDate = DateTime.Now;

        // Mise à jour de dates spécifiques selon le statut
        if (newStatus == TicketStatus.Resolved && !ticket.ResolutionDate.HasValue)
        {
            ticket.ResolutionDate = DateTime.Now;
        }
        else if (newStatus == TicketStatus.Closed && !ticket.ClosedDate.HasValue)
        {
            ticket.ClosedDate = DateTime.Now;
        }

        await _ticketRepository.UpdateAsync(ticket);

        // Ajout d'une entrée dans l'historique
        await _historyService.AddHistoryEntryAsync(new TicketHistory
        {
            TicketID = ticketId,
            ChangedByUserId = userId,
            FieldName = "Status",
            OldValue = oldStatus.ToString(),
            NewValue = newStatus.ToString()
        });

        return ticket;
    }

    public async Task<Ticket> AssignTicketAsync(int ticketId, string assignedToUserId, string updatedByUserId)
    {
        var ticket = await _ticketRepository.GetByIdAsync(ticketId);
        if (ticket == null)
        {
            throw new KeyNotFoundException($"Ticket with ID {ticketId} not found");
        }

        var oldAssignedUser = ticket.AssignedToUserId;
        ticket.AssignedToUserId = assignedToUserId;
        ticket.AssignedToTeamID = null; // Désassigner de l'équipe si assigné à un utilisateur
        ticket.UpdatedDate = DateTime.Now;

        await _ticketRepository.UpdateAsync(ticket);

        // Ajout d'une entrée dans l'historique
        await _historyService.AddHistoryEntryAsync(new TicketHistory
        {
            TicketID = ticketId,
            ChangedByUserId = updatedByUserId,
            FieldName = "AssignedToUser",
            OldValue = oldAssignedUser ?? "Unassigned",
            NewValue = assignedToUserId ?? "Unassigned"
        });

        return ticket;
    }

    public async Task<Ticket> AssignTicketToTeamAsync(int ticketId, int teamId, string updatedByUserId)
    {
        var ticket = await _ticketRepository.GetByIdAsync(ticketId);
        if (ticket == null)
        {
            throw new KeyNotFoundException($"Ticket with ID {ticketId} not found");
        }

        var oldTeamId = ticket.AssignedToTeamID;
        ticket.AssignedToTeamID = teamId;
        ticket.AssignedToUserId = null; // Désassigner de l'utilisateur si assigné à une équipe
        ticket.UpdatedDate = DateTime.Now;

        await _ticketRepository.UpdateAsync(ticket);

        // Ajout d'une entrée dans l'historique
        await _historyService.AddHistoryEntryAsync(new TicketHistory
        {
            TicketID = ticketId,
            ChangedByUserId = updatedByUserId,
            FieldName = "AssignedToTeam",
            OldValue = oldTeamId?.ToString() ?? "Unassigned",
            NewValue = teamId.ToString()
        });

        return ticket;
    }

    public async Task<int> GetTicketCountByStatusAsync(TicketStatus status)
    {
        return await _ticketRepository.GetTicketCountByStatusAsync(status);
    }

    public async Task<Dictionary<TicketStatus, int>> GetTicketStatusDistributionAsync()
    {
        var result = new Dictionary<TicketStatus, int>();

        // Obtenir tous les statuts possibles (à partir de l'énumération)
        var statuses = Enum.GetValues(typeof(TicketStatus)).Cast<TicketStatus>();

        // Pour chaque statut, obtenir le nombre de tickets
        foreach (var status in statuses)
        {
            int count = await _ticketRepository.GetTicketCountByStatusAsync(status);
            result.Add(status, count);
        }

        return result;
    }

    public async Task<Dictionary<TicketPriority, int>> GetTicketPriorityDistributionAsync()
    {
        var result = new Dictionary<TicketPriority, int>();
        var allTickets = await _ticketRepository.GetAllAsync();

        // Obtenir tous les niveaux de priorité possibles
        var priorities = Enum.GetValues(typeof(TicketPriority)).Cast<TicketPriority>();

        // Pour chaque priorité, compter les tickets
        foreach (var priority in priorities)
        {
            int count = allTickets.Count(t => t.Priority == priority);
            result.Add(priority, count);
        }

        return result;
    }
}
