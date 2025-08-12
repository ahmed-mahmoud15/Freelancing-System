using FreelancingSystem.Models;

namespace FreelancingSystem.Service
{
    public interface IJobSkillService
    {
        IEnumerable<JobSkill> GetAllJobSkills();
        JobSkill GetJobSkillById(int id);
        void AddJobSkill(JobSkill skill);
        void UpdateJobSkill(JobSkill skill);
        void DeleteJobSkill(int id);
    }
}