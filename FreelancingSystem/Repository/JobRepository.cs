using FreelancingSystem.Data;
using FreelancingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace FreelancingSystem.Repository
{
    public class JobRepository : Repository<Job>, IJobRepository
    {

        public JobRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Job> GetJobsByClientId(int id)
        {
            return context.Jobs.Where(x => x.ClientId == id).Include(x => x.Client).ToList();
        }
    }
}