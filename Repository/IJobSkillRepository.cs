
using FreelancingSystem.Models;

namespace FreelancingSystem.Repository
{
    public interface IJobSkillRepository : IRepository<JobSkill>
    {
        JobSkill GetJobSkillByIdentityId(string id);
    }
}
