using System.ComponentModel.DataAnnotations;

namespace Ticketing_System.Models
{
    public class Notification
    {
        public int NotificationID { get; set; }

        [Required]
        public string UserID { get; set; }

        [Required]
        public int TicketID { get; set; }

        [Required, MaxLength(50)]
        public string NotificationType { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public bool IsRead { get; set; } = false;

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual User User { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
