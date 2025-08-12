using FreelancingSystem.Data;
using FreelancingSystem.Models;

namespace FreelancingSystem.Repository
{
    public class JobCategoryRepository : Repository<JobCategory>, IJobCategoryRepository
    {

        public JobCategoryRepository(ApplicationDbContext context) : base(context) { }

        public JobCategory GetJobCategoryByIdentityId(string id)
        {
            return table.FirstOrDefault(e => e.IdentityId.Equals(id));
        }
    }
}