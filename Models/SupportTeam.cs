using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace Ticketing_System.Models
{
    public class SupportTeam
    {
        [Key]
        public int TeamID { get; set; }

        [Required, MaxLength(100)]
        public string TeamName { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public string ManagerId { get; set; }

        [ForeignKey("ManagerId")]
        public virtual User Manager { get; set; }

        public virtual ICollection<TeamMember> TeamMembers { get; set; }

        // Tickets assignés à l’équipe
        public virtual ICollection<Ticket> AssignedTickets { get; set; }
    }
}

