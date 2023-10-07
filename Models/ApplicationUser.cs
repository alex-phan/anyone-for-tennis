using AnyoneForTennis.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AnyoneForTennis.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, StringLength(50), Display(Name = "First Name"), PersonalData]
        public string FirstName { get; set; }
        [Required, StringLength(50), Display(Name = "Last Name"), PersonalData]
        public string LastName { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Date of Birth"), PersonalData]
        public DateTime? DateOfBirth { get; set; }
        [PersonalData]
        public Gender? Gender { get; set; }
        [StringLength(300), PersonalData]
        public string? Biography { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }

    public enum Gender { 
        Male,
        Female
    }
}
