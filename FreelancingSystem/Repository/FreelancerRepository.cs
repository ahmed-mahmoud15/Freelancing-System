using FreelancingSystem.Data;
using FreelancingSystem.Models;

namespace FreelancingSystem.Repository
{
    public class FreelancerRepository : Repository<Freelancer>, IFreelancerRepository
    {

        public FreelancerRepository(ApplicationDbContext context) : base(context) { }

        public Freelancer GetFreelancerByIdentityId(string id)
        {
            return table.FirstOrDefault(e => e.IdentityId.Equals(id));
        }
    }
}