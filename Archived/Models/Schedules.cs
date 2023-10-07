using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AnyoneForTennis.Models
{
    public class Schedules 
    {
        public static int ScheduleId { get; set; }
        public int id1 { get; set; }
        public int id2 { get; set; }
        [Required]
        [Display(Name = "Event Name")]
        public string EventName { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }
        public static int CoachId { get; set; } // Foreign key to link with Coach

        public Coach Coach { get; set; } // Navigation property to access associated coach

        public static IEnumerable? ScheduleIds { get; set; }
        public static IEnumerable? CoachesIds { get; set; }
        public static List<Coach>? Coaches { get; set;}
        public int MemberId { get; set; }
        public Members Member { get; set; }

        // Add other schedule-specific properties as needed
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
