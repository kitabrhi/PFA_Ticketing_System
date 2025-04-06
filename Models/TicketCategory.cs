using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace Ticketing_System.Models
{
    public class TicketCategory
    {
        [Key]
        public int CategoryID { get; set; }

        [Required, MaxLength(100)]
        public string CategoryName { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public int? ParentCategoryID { get; set; }

        // Navigation properties
        public virtual TicketCategory ParentCategory { get; set; }
        public virtual ICollection<TicketCategory> ChildCategories { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<KnowledgeBaseArticle> KnowledgeBaseArticles { get; set; }
        public virtual ICollection<AssignmentRule> AssignmentRules { get; set; }
    }
}
