

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

        [DisplayName("Display Order")]
        [MinLength(2, ErrorMessage = "Minimum length is 2 characters!")]
        [MaxLength(25, ErrorMessage = "Max length is 25 characters!")]
        public string Nick { get; set; }
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
