using System.ComponentModel.DataAnnotations;

namespace Ticketing_System.Models
{
    public class UserPreference
    {
        [Key]
        public string UserID { get; set; }

        [Required]
        public bool EmailNotifications { get; set; } = true;

        [Required]
        public bool InAppNotifications { get; set; } = true;

        [Required]
        public bool DarkModeEnabled { get; set; } = false;

        [Required]
        public int ItemsPerPage { get; set; } = 20;

        [Required, MaxLength(50)]
        public string DefaultDashboard { get; set; } = "default";

        // Navigation property
        public virtual User User { get; set; }
    }
}
