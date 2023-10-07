using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AnyoneForTennis.Models
{
    public class Members
    {
        public int MemberId { get; set; }

        public string eventname { get; set; }
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

        // Add other member-specific properties here
    }
}
