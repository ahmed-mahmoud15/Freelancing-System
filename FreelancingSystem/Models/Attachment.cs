using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreelancingSystem.Models
{
    public class Attachment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Path { get; set; }

        [ForeignKey(nameof(Job))]
        public int JobId { get; set; }
        public Job Job { get; set; } = null!;

    }
}
