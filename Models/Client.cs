using System.ComponentModel.DataAnnotations;

namespace FreelancingSystem.Models
{
    public class Client : User
    {
        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }

        public ICollection<Job> Jobs { get; set; } = new List<Job>();

    }
}
