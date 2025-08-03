namespace FreelancingSystem.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<FreelancerSkill> Freelancers { get; set; }
    }
}
