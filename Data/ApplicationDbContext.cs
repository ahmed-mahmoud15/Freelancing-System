using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FreelancingSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Rating> Ratings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Keep Identity tables configuration

            // rating entity configuration
            modelBuilder.Entity<Rating>()
                .HasOne(o => o.Reviewer)
                .WithMany(u => u.ReviewerRatings)
                .HasForeignKey(o => o.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Reviewee)
                .WithMany(u => u.RevieweeRatings)
                .HasForeignKey(o => o.RevieweeIdh)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
}
