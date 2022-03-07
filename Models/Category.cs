

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace dotNETBlog.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        
        [Range(1, 100, ErrorMessage = "Values from 1 to 100 range")]
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
