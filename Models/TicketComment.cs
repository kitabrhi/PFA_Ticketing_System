using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace Ticketing_System.Models
{
    public class TicketComment
    {
        [Key]
        public int CommentID { get; set; }

        [Required]
        public int TicketID { get; set; }

        [Required]
        public string UserId { get; set; }

        // Texte du commentaire ou de la note interne
        [Required]
        public string CommentText { get; set; }

        // Indique si le commentaire est interne (seul le personnel de support peut le voir)
        public bool IsInternal { get; set; } = false;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [ForeignKey("TicketID")]
        public virtual Ticket Ticket { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}

