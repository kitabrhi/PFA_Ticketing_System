using System.ComponentModel.DataAnnotations;

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

        public int? PriorityID { get; set; }

        public int? StatusID { get; set; }

        [Required]
        public int EscalateAfterHours { get; set; }

        public string EscalateToUserID { get; set; }

        public int? EscalateToTeamID { get; set; }

        public string NotifyUserIDs { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual TicketPriority Priority { get; set; }
        public virtual TicketStatus Status { get; set; }
        public virtual User EscalateToUser { get; set; }
        public virtual SupportTeam EscalateToTeam { get; set; }
    }
}
