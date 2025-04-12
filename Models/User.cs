using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Net.Sockets;

namespace Ticketing_System.Models
{
    public class User : IdentityUser
    {
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? LastLoginDate { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual ICollection<Ticket> CreatedTickets { get; set; }
        public virtual ICollection<Ticket> AssignedTickets { get; set; }
        public virtual ICollection<SupportTeam> ManagedTeams { get; set; }
        public virtual ICollection<TeamMember> TeamMemberships { get; set; }
        public virtual ICollection<TicketComment> Comments { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<TicketHistory> TicketChanges { get; set; }
        public virtual ICollection<KnowledgeBaseArticle> Articles { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
       
    }
}

