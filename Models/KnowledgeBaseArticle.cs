using System.ComponentModel.DataAnnotations;

namespace Ticketing_System.Models
{
    public class KnowledgeBaseArticle
    {
        [Key]
        public int ArticleID { get; set; }

        [Required, MaxLength(255)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int? CategoryID { get; set; }

        [Required]
        public string AuthorID { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        [Required]
        public bool IsPublished { get; set; } = false;

        [Required]
        public int ViewCount { get; set; } = 0;

        // Navigation properties
        public virtual TicketCategory Category { get; set; }
        public virtual User Author { get; set; }
    }
}
