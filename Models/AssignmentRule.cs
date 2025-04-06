using System.ComponentModel.DataAnnotations;

namespace Ticketing_System.Models
{
    public class AssignmentRule
    {
        [Key]
        public int RuleID { get; set; }

        [Required, MaxLength(100)]
        public string RuleName { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public int? CategoryID { get; set; }

        public int? PriorityID { get; set; }

        public int? AssignToTeamID { get; set; }

        public string AssignToUserID { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public int RuleOrder { get; set; }

        // Navigation properties
        public virtual TicketCategory Category { get; set; }
        public virtual TicketPriority Priority { get; set; }
        public virtual SupportTeam AssignToTeam { get; set; }
        public virtual User AssignToUser { get; set; }
    }
}
