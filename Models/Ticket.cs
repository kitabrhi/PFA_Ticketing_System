using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Ticketing_System.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }

        [Required, MaxLength(255)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Required]
        public int PriorityID { get; set; }

        [Required]
        public int StatusID { get; set; }

        [Required]
        public string CreatedByUserID { get; set; }

        public string AssignedToUserID { get; set; }

        public int? AssignedToTeamID { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public DateTime? DueDate { get; set; }

        public DateTime? ResolutionDate { get; set; }

        public DateTime? ClosedDate { get; set; }

        [Required, MaxLength(50)]
        public string Source { get; set; }

        [Required]
        public bool IsEscalated { get; set; } = false;

        // Navigation properties
        public virtual TicketCategory Category { get; set; }
        public virtual TicketPriority Priority { get; set; }
        public virtual TicketStatus Status { get; set; }
        public virtual User CreatedByUser { get; set; }
        public virtual User AssignedToUser { get; set; }
        public virtual SupportTeam AssignedToTeam { get; set; }
        public virtual ICollection<TicketComment> Comments { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<TicketHistory> History { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
