using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace dotNETBlog.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString("D");

        [EmailAddress]
        [RegularExpression(@"\b[a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}\b", ErrorMessage = "Please input valid email")]
        [Required(ErrorMessage = "Email is required to login/register")]
        [DisplayName("User email adress")]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? PasswordHash { get; set; }

        [DisplayName("User nickname")]
        [RegularExpression(@"[a-zA-Z]", ErrorMessage = "Your nickname can contain only a-z and A-Z characters")]
        public string? Nick { get; set; }


        public DateTime UserCreatedDateTime { get; set; } = DateTime.Now;
    }
}
