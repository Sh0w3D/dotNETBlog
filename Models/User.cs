using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotNETBlog.Models
{
    
    [Table("user", Schema = "public")]
    public class User
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString("D");

        [EmailAddress]
        [Required(ErrorMessage = "Email is required to login/register")]
        [DisplayName("User email adress")]
        public string? Email { get; set; }


        [DataType(DataType.Password)]
        public string? PasswordHash { get; set; }

        [DisplayName("User nickname")]
        [MinLength(2, ErrorMessage = "Min length is 2 characters!")]
        [MaxLength(25, ErrorMessage = "Max length is 25 characters!")]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "The nick cannot contain any special character!")]
        public string? Nick { get; set; }

        public DateTime UserCreatedDateTime { get; set; } = DateTime.UtcNow;
    }
}
