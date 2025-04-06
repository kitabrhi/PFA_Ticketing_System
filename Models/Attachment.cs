using System.ComponentModel.DataAnnotations;

namespace Ticketing_System.Models
{
    public class Attachment
    {
        public int AttachmentID { get; set; }

        [Required]
        public int TicketID { get; set; }

        public int? CommentID { get; set; }

        [Required, MaxLength(255)]
        public string FileName { get; set; }

        [Required]
        public long FileSize { get; set; }

        [Required, MaxLength(100)]
        public string ContentType { get; set; }

        [Required, MaxLength(500)]
        public string FilePath { get; set; }

        [Required]
        public string UploadedByUserID { get; set; }

        [Required]
        public DateTime UploadDate { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual Ticket Ticket { get; set; }
        public virtual TicketComment Comment { get; set; }
        public virtual User UploadedByUser { get; set; }
    }
}
