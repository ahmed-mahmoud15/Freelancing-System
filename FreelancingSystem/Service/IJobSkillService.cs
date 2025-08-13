using FreelancingSystem.Models;
using System.Collections.Generic;

namespace FreelancingSystem.Service
{
    public interface IJobSkillService
    {
        IEnumerable<JobSkill> GetAllJobSkills();
        JobSkill GetJobSkillByIds(int jobId, int skillId);
        void CreateJobSkill(JobSkill jobSkill);
        void UpdateJobSkill(JobSkill jobSkill);
        void DeleteJobSkill(int jobId, int skillId);
    }
}
