using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing_System.Models
{
    public class EscalationRule
    {
        [Key]
        public int RuleID { get; set; }

        [Required, MaxLength(100)]
        public string RuleName { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        // Critères d'escalade basés sur la priorité et le statut du ticket.
        public TicketPriority? Priority { get; set; }
        public TicketStatus? Status { get; set; }

        [Required]
        public int EscalateAfterHours { get; set; }

        // Références pour l'escalade automatique vers un utilisateur ou une équipe.
        public string EscalateToUserID { get; set; }
        public int? EscalateToTeamID { get; set; }

        // Liste de IDs d'utilisateurs à notifier (pouvant être gérée comme une chaîne séparée par des virgules ou autrement)
        [MaxLength(500)]
        public string NotifyUserIDs { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        // Navigation properties
        [ForeignKey("EscalateToUserID")]
        public virtual User EscalateToUser { get; set; }

        [ForeignKey("EscalateToTeamID")]
        public virtual SupportTeam EscalateToTeam { get; set; }
    }
}
