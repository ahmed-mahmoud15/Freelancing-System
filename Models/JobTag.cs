using System.ComponentModel.DataAnnotations.Schema;

namespace FreelancingSystem.Models
{
    public class JobTag
    {
        [ForeignKey(nameof(Job))]
        public int JobId { get; set; }
        [ForeignKey(nameof(Tag))]
        public int TagId { get; set; }

        public Job Job { get; set; }

        public Tag Tag { get; set; }
    }
}
