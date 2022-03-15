

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace dotNETBlog.Models
{
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

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public bool Published { get; set; } = false;

    }
}
