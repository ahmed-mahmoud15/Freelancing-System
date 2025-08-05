using FreelancingSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FreelancingSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<User> Users {  get; set; }
        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Job> Jobs { get; set; }

        public DbSet<Proposal> Proposals { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Attachment> Attachments { get; set; }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<JobSkill> JobSkills { get; set; }

        public DbSet<JobTag> JobTags { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Keep Identity tables configuration

            // TPT or TPC

            // Composite Primary Keys

            //many to many relations


            // configure ondelete actions


        }
    }
}
