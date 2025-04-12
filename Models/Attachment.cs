using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing_System.Models
{
    public class Attachment
    {
        [Key]
        public int AttachmentId { get; set; }

        [Required]
        public int TicketID { get; set; }

        [Required, MaxLength(255)]
        public string FileName { get; set; }

        [Required]
        public string FilePath { get; set; }

        public DateTime UploadedDate { get; set; } = DateTime.Now;

        [Required]
        public string UploaderUserId { get; set; }

        [ForeignKey("TicketID")]
        public virtual Ticket Ticket { get; set; }

        [ForeignKey("UploaderUserId")]
        public virtual User Uploader { get; set; }
    }
}
