using FreelancingSystem.Data;
using FreelancingSystem.Models;

namespace FreelancingSystem.Repository
{
    public class JobRepository : Repository<Job>, IJobRepository
    {

        public JobRepository(ApplicationDbContext context) : base(context) { }

        public Job GetJobById(string id)
        {
            return table.FirstOrDefault(e => e.Id.Equals(id));
        }
    }
}