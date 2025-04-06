using System.ComponentModel.DataAnnotations;

namespace Ticketing_System.Models
{
    public class TicketHistory
    {
        public int HistoryID { get; set; }

        [Required]
        public int TicketID { get; set; }

        [Required, MaxLength(100)]
        public string FieldName { get; set; }

        public string OldValue { get; set; }

        public string NewValue { get; set; }

        [Required]
        public string ChangedByUserID { get; set; }

        [Required]
        public DateTime ChangedDate { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual Ticket Ticket { get; set; }
        public virtual User ChangedByUser { get; set; }
    }
}
