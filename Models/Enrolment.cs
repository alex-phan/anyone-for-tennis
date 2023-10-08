namespace AnyoneForTennis.Models
{
    public class Enrolment
    {
        public int Id { get; set; }
        public Schedule Schedule { get; set; }
        public ApplicationUser Coach { get; set; }
        public ICollection<ApplicationUser> Enrolments { get; set; }
    }
}
