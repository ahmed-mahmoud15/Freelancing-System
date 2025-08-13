using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreelancingSystem.Models
{
    public class Proposal
    {
        [ForeignKey(nameof(Job))]
        public int JobId { get; set; }
        [ForeignKey(nameof(Freelancer))]
        public int FreelancerId { get; set; }

        [Required]
        public string CoverLetter { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
        public int Bid {  get; set; }
        public Status? Status { get; set; } = Models.Status.Applied;
        
        public Freelancer Freelancer { get; set; }
        public Job Job { get; set; }

    }
}
