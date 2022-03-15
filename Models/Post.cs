

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotNETBlog.Models
{
    [Table("post", Schema = "public")]
    public class Post
    {
        [Key]
        public string? Id { get; set; } = Guid.NewGuid().ToString("D");

        [Required]
        public string AuthorID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public bool Published { get; set; } = false;

    }
}
