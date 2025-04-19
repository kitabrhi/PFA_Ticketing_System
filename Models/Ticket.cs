using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace Ticketing_System.Models
{
    public class Ticket
    {
        internal string? UpdatedByUserId;

        [Key]
        public int TicketID { get; set; }  // La numérotation automatique sera assurée par EF Core (IDENTITY)

        [Required, MaxLength(255)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public TicketCategory Category { get; set; }

        [Required]
        public TicketPriority Priority { get; set; }

        [Required]
        public TicketStatus Status { get; set; }

        // Utilisation des identifiants des utilisateurs gérés par Identity (de type string)
        [Required]
        public string CreatedByUserId { get; set; }

        public string? AssignedToUserId { get; set; }

        public int? AssignedToTeamID { get; set; }

        // Dates importantes
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public DateTime? DueDate { get; set; }
        public DateTime? ResolutionDate { get; set; }
        public DateTime? ClosedDate { get; set; }

        // Source de création : Web, Email, Mobile, etc.
        [Required, MaxLength(50)]
        public string Source { get; set; }

        // Pour la gestion de l'escalade
        public bool IsEscalated { get; set; } = false;

        // Navigation properties
        [ForeignKey("CreatedByUserId")]
        public virtual User CreatedByUser { get; set; }

        [ForeignKey("AssignedToUserId")]
        public virtual User AssignedToUser { get; set; }

        [ForeignKey("AssignedToTeamID")]
        public virtual SupportTeam AssignedToTeam { get; set; }

        // Les collections pour l’historique, commentaires et attachements
        public virtual ICollection<TicketHistory> TicketHistories { get; set; }
        public virtual ICollection<TicketComment> TicketComments { get; set; }
        public virtual ICollection<Attachment> TicketAttachments { get; set; }
    }
}
