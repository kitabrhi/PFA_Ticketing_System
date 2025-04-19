using Ticketing_System.Models;
using Ticketing_System.Service_Layer.Interfaces;

namespace Ticketing_System.Service_Layer.Service
{
    public class TicketHistoryService : ITicketHistoryService
    {
        private readonly ITicketHistoryRepository _historyRepository;

        public TicketHistoryService(ITicketHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }

        public async Task<IEnumerable<TicketHistory>> GetHistoryByTicketIdAsync(int ticketId)
        {
            return await _historyRepository.GetHistoryByTicketIdAsync(ticketId);
        }

        public async Task<TicketHistory> AddHistoryEntryAsync(TicketHistory history)
        {
            if (history == null) throw new ArgumentNullException(nameof(history));

            history.ChangedDate = DateTime.Now;
            return await _historyRepository.AddAsync(history);
        }
    }
}
