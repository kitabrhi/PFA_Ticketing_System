using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ticketing_System.Models;

public class AssignmentRule
{
    [Key]
    public int RuleID { get; set; }

    [Required, MaxLength(100)]
    public string RuleName { get; set; }

    [MaxLength(255)]
    public string Description { get; set; }

    // Utilisation des enums pour définir des critères de correspondance de ticket.
    // Les valeurs nulles signifient que le critère n'est pas pris en compte.
    public TicketCategory? Category { get; set; }
    public TicketPriority? Priority { get; set; }

    // Référence d'assignation à une équipe ou à un utilisateur.
    public int? AssignToTeamID { get; set; }
    public string AssignToUserID { get; set; }

    [Required]
    public bool IsActive { get; set; } = true;

    [Required]
    public int RuleOrder { get; set; }

    // Navigation properties
    [ForeignKey("AssignToTeamID")]
    public virtual SupportTeam AssignToTeam { get; set; }

    [ForeignKey("AssignToUserID")]
    public virtual User AssignToUser { get; set; }
}