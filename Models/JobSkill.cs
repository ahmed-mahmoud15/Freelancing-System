using System.ComponentModel.DataAnnotations.Schema;

namespace FreelancingSystem.Models
{
    public class JobSkill
    {
        [ForeignKey(nameof(Job))]
        public int JobId { get; set; }
        [ForeignKey(nameof(Skill))]
        public int SkillId { get; set; }

        public Job Job { get; set; }

        public Skill Skill { get; set; }
    }
}