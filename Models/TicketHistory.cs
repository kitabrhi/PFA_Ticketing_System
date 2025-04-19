using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing_System.Models
{
    public class TicketHistory
    {
        [Key]
        public int TicketHistoryID { get; set; }

        [Required]
        public int TicketID { get; set; }

        [Required]
        public string ChangedByUserId { get; set; }

        [Required, MaxLength(100)]
        public string FieldName { get; set; }

        [MaxLength(255)]
        public string OldValue { get; set; }

        [MaxLength(255)]
        public string NewValue { get; set; }

        public DateTime ChangedDate { get; set; } = DateTime.Now;

        [ForeignKey("ChangedByUserId")]
        public virtual User ChangedByUser { get; set; }

    }
}
