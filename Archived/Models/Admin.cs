using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AnyoneForTennis.Models
{
    public class Admin
    {
        public int AdminId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PasswordHash { get; set; }

        // Add other admin-specific properties here
    }
}
