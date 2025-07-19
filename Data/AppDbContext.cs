using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FFCProject.Models;

namespace FFCProject.Data
{
    // Inherit from IdentityDbContext with ApplicationUser to integrate ASP.NET Core Identity
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        // Your existing domain tables are kept intact
        public DbSet<OtpEntry> OtpEntries { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Asset> Assets { get; set; }

        // Optional: override OnModelCreating if you want to customize Identity or your own tables further
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Example: add custom constraints or relationships if needed
            // builder.Entity<Employee>().HasIndex(e => e.Email).IsUnique();

            // Add any additional Fluent API configurations here
        }
    }
}
