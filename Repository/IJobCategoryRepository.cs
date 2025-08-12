
using FreelancingSystem.Models;

namespace FreelancingSystem.Repository
{
    public interface IJobCategoryRepository : IRepository<JobCategory>
    {
        JobCategory GetJobCategoryByIdentityId(string id);
    }
}
