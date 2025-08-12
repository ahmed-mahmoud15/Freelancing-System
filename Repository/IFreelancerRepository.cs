using FreelancingSystem.Models;

namespace FreelancingSystem.Repository
{
    public interface IFreelancerRepository : IRepository<Freelancer>
    {
        Client GetFreelancerByIdentityId(string id);
    }
}