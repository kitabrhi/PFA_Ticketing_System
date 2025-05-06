using System.Collections.Generic;
using Ticketing_System.Models;

namespace Ticketing_System.Models
{
    public class DashboardViewModel
    {
        // KPI
        public int TotalTickets { get; set; }
        public int NewTickets { get; set; }
        public int InProgressTickets { get; set; }
        public int ResolvedTickets { get; set; }
        public int ClosedTickets { get; set; }

        // Répartition (pour le donut chart)
        public Dictionary<TicketStatus, int> StatusDistribution { get; set; } = new();

        // 5 derniers tickets
        public IEnumerable<Ticket> RecentTickets { get; set; }
    }
}
