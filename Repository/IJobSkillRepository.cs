using FreelancingSystem.Models;
using System.Collections.Generic;

namespace FreelancingSystem.Repository
{
    public interface IJobSkillRepository
    {
        IEnumerable<JobSkill> GetAll();
        JobSkill GetByIds(int jobId, int skillId);
        void Insert(JobSkill jobSkill);
        void Update(JobSkill jobSkill);
        void Delete(int jobId, int skillId);
        void Save();
    }
}
