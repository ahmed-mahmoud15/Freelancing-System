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

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<Freelancer>().ToTable("Freelancers");

            // Composite Primary Keys

            modelBuilder.Entity<FreelancerSkill>().HasKey(e => new { e.FreelancerId, e.SkillId });

            modelBuilder.Entity<JobCategory>().HasKey(e => new { e.JobId, e.CategoryId});

            modelBuilder.Entity<JobSkill>().HasKey(e => new {e.JobId, e.SkillId});

            modelBuilder.Entity<JobTag>().HasKey(e => new {e.JobId, e.TagId});

            modelBuilder.Entity<Proposal>().HasKey(e => new {e.JobId, e.FreelancerId});

            modelBuilder.Entity<Rating>().HasKey(e => new {e.ReviewerId, e.RevieweeId});


            // Seed Data

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Web Development" },
                new Category { Id = 2, Name = "Graphic Design" },
                new Category { Id = 3, Name = "Mobile Development" }
            );

            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "C#" },
                new Skill { Id = 2, Name = "JavaScript" },
                new Skill { Id = 3, Name = "Photoshop" },
                new Skill { Id = 4, Name = ".NET" }
            );

            modelBuilder.Entity<Tag>().HasData(
                new Tag { Id = 1, Name = "Urgent" },
                new Tag { Id = 2, Name = "Remote" },
                new Tag { Id = 3, Name = "Full-Time" },
                new Tag { Id = 4, Name = "Part-Time"}
            );

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
        .Where(e => !e.GetTableName()!.StartsWith("AspNet")) // Skip Identity tables
        .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
