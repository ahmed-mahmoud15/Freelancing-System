using System.ComponentModel.DataAnnotations.Schema;

namespace FreelancingSystem.Models
{
    public class Proposal
    {
        [ForeignKey(nameof(Job))]
        public int JobId { get; set; }
        [ForeignKey(nameof(Freelancer))]
        public int FreelancerId { get; set; }

        public DateTime date { get; set; }
        public string CoverLetter { get; set; }
        public int bid {  get; set; }
        public DateTime TimeLine { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        
        public Freelancer Freelancer { get; set; }
        public Job Job { get; set; }

    }
}
