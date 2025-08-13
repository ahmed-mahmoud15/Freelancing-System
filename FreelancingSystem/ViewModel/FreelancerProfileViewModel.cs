namespace FreelancingSystem.ViewModel
{
    public class FreelancerProfileViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Bio { get; set; }

        public string PhotoPath { get; set; }

        public IEnumerable<ShowFreelancerProposalViewModel> Proposals { get; set; }
    }
}
