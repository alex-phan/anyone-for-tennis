using AnyoneForTennis.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnyoneForTennis.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AnyoneForTennis.Models.Schedule> Schedule { get; set; } = default!;
        public DbSet<AnyoneForTennis.Models.Enrolment> Enrolment { get; set; } = default!;
    }
}