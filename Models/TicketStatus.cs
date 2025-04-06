using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace Ticketing_System.Models
{
    public class TicketStatus
    {
        public int StatusID { get; set; }

        [Required, MaxLength(50)]
        public string StatusName { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public bool IsClosedStatus { get; set; } = false;

        // Navigation properties
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<EscalationRule> EscalationRules { get; set; }
    }
}
