using FreelancingSystem.Models;

namespace FreelancingSystem.ViewModel
{
    public class ShowFreelancerProposalViewModel
    {
        public int JobId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public int Bid { get; set; }
        public string CoverLetter { get; set; }

        public Status Status { get; set; }

    }
}
