using System.ComponentModel.DataAnnotations.Schema;

namespace FreelancingSystem.Models
{
    public class FreelancerSkill
    {
        [ForeignKey(nameof(Freelancer))]
        public int FreelancerId { get; set; }
        [ForeignKey(nameof(Skill))]
        public int SkillId { get; set; }

        public Freelancer Freelancer { get; set; }

        public Skill Skill { get; set; }

    }
}
