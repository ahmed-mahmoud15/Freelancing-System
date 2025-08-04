namespace FreelancingSystem.Models
{
    public class Freelancer : User
    {
        public string? Bio { get; set; }

        public ICollection<FreelancerSkill> Skills { get; set; }
        public ICollection<Proposal> Proposals { get; set; }

    }
}
