using FreelancingSystem.Models;

namespace FreelancingSystem.Repository
{
    public interface IJobRepository : IRepository<Job>
    {
        Job GetJobById(string id);
    }
}