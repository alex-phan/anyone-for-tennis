using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AnyoneForTennis.Models
{
    public class Coach
    {
        public int CoachId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PasswordHash { get; set; }

        [Display(Name = "Biography")]
        public string Biography { get; set; }

        // Add other coach-specific properties here
    }
}
