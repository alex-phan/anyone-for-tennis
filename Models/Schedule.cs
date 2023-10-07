using System.ComponentModel.DataAnnotations;

namespace AnyoneForTennis.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        [Required, StringLength(50), Display(Name = "Event Name")]
        public string EventName { get; set; }
        [Required, DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Event Name")]
        public string EventDate { get; set; }
        [Required, StringLength(100), Display(Name = "Event Location")]
        public string EventLocation { get; set; }
        [StringLength(300), Display(Name = "Event Description")]
        public string EventDescription { get; set; }

        public virtual ApplicationUser Coach { get; set; }
        public virtual ICollection<ApplicationUser> Enrolments { get; set; }
    }
}
