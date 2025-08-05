using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace FreelancingSystem.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? ProfileImagePath { get; set; }

        [ForeignKey(nameof(IdentityUser))]
        public Guid IdentityId { get; set; }

        public IdentityUser IdentityUser { get; set; }
        public ICollection<Rating> ReviewerRatings { get; set; }
        public ICollection<Rating> RevieweeRatings { get; set; }


    }
}
