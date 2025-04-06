using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace Ticketing_System.Models
{
    public class TicketPriority
    {
        public int PriorityID { get; set; }

        [Required, MaxLength(50)]
        public string PriorityName { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public int SLAResponseHours { get; set; }

        [Required]
        public int SLAResolutionHours { get; set; }

        // Navigation properties
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<AssignmentRule> AssignmentRules { get; set; }
        public virtual ICollection<EscalationRule> EscalationRules { get; set; }
    }
}
