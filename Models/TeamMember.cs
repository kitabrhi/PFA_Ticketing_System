using System.ComponentModel.DataAnnotations;

namespace Ticketing_System.Models
{
    public class TeamMember
    {
        public int TeamID { get; set; }
        public string UserID { get; set; }

        [Required]
        public DateTime JoinDate { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual SupportTeam Team { get; set; }
        public virtual User User { get; set; }
    }
}
