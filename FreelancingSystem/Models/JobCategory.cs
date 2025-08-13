using System.ComponentModel.DataAnnotations.Schema;

namespace FreelancingSystem.Models
{
    public class JobCategory
    {
        [ForeignKey(nameof(Job))]
        public int JobId { get; set; }
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public Job Job { get; set; }

        public Category Category { get; set; }
    }
}
