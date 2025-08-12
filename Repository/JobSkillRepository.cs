using FreelancingSystem.Data;
using FreelancingSystem.Models;

namespace FreelancingSystem.Repository
{
    public class JobSkillRepository : Repository<JobSkill>, IJobSkillRepository
    {

        public JobSkillRepository(ApplicationDbContext context) : base(context) { }

        public JobSkill GetJobSkillByIdentityId(string id)
        {
            return table.FirstOrDefault(e => e.IdentityId.Equals(id));
        }
    }
}