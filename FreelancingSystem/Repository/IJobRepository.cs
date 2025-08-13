using FreelancingSystem.Models;

namespace FreelancingSystem.Repository
{
    public interface IJobRepository : IRepository<Job>
    {
        IEnumerable<Job> GetJobsByClientId(int id);

        IEnumerable<Job> GetJobsNotAppliedByFreelancer(int freelancerId);
    }
}