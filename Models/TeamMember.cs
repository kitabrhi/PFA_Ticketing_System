using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing_System.Models
{
    public class TeamMember
    {
      
            [Key]
            public int TeamMemberID { get; set; }

            [Required]
            public int TeamID { get; set; }

            [Required]
            public string UserId { get; set; }

            public DateTime JoinDate { get; set; } = DateTime.Now;

            [ForeignKey("TeamID")]
            public virtual SupportTeam Team { get; set; }

            [ForeignKey("UserId")]
            public virtual User User { get; set; }
        }
    }

