using System.ComponentModel.DataAnnotations;

namespace FreelancingSystem.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<JobCategory> Jobs { get; set; } = new List<JobCategory>();

    }
}
