using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace Ticketing_System.Models
{
    public class SupportTeam
    {
        public int TeamID { get; set; }

        [Required, MaxLength(100)]
        public string TeamName { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public string ManagerID { get; set; }

        // Navigation properties
        public virtual User Manager { get; set; }
        public virtual ICollection<TeamMember> TeamMembers { get; set; }
        public virtual ICollection<Ticket> AssignedTickets { get; set; }
        public virtual ICollection<AssignmentRule> AssignmentRules { get; set; }
        public virtual ICollection<EscalationRule> EscalationRules { get; set; }
    }
}
