using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Ticketing_System.Models
{
    public class TicketComment
    {
        public int CommentID { get; set; }

        [Required]
        public int TicketID { get; set; }

        [Required]
        public string UserID { get; set; }

        [Required]
        public string CommentText { get; set; }

        [Required]
        public DateTime CommentDate { get; set; } = DateTime.Now;

        [Required]
        public bool IsInternal { get; set; } = false;

        // Navigation properties
        public virtual Ticket Ticket { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}
