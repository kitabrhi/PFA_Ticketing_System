using Ticketing_System.Models;
using Ticketing_System.Repository_Pattern.Interfaces;
using Ticketing_System.Service_Layer.Interfaces;

namespace Ticketing_System.Service_Layer.Service
{
    public class TicketHistoryService : ITicketHistoryService
    {
        private readonly ITicketHistoryRepository _historyRepository;
        private readonly IUserRepository _userRepository;

        public TicketHistoryService(
            ITicketHistoryRepository historyRepository,
            IUserRepository userRepository)
        {
            _historyRepository = historyRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<TicketHistory>> GetHistoryByTicketIdAsync(int ticketId)
        {
            return await _historyRepository.GetHistoryByTicketIdAsync(ticketId);
        }

        public async Task<TicketHistory> AddHistoryEntryAsync(TicketHistory history)
        {
            if (history == null) throw new ArgumentNullException(nameof(history));

            // Vérifier si l'utilisateur existe
            bool userExists = await _userRepository.UserExistsAsync(history.ChangedByUserId);
            if (!userExists && history.ChangedByUserId != "SYSTEM")
            {
                // Utiliser un ID système par défaut
                history.ChangedByUserId = "system"; // Assurez-vous que cet ID existe
            }

            history.ChangedDate = DateTime.Now;
            return await _historyRepository.AddAsync(history);
        }
    }
}