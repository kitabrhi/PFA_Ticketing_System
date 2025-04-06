using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Ticketing_System.Models
{
    public class Role : IdentityRole
    {
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
