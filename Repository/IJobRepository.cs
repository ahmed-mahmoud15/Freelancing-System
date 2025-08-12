using FreelancingSystem.Models;

namespace FreelancingSystem.Repository
{
    public interface IJobRepository : IRepository<Job>
    {
        Job GetJobByIdentityId(string id);
    }
}