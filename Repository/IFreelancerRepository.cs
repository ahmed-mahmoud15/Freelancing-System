using FreelancingSystem.Models;

namespace FreelancingSystem.Repository
{
    public interface IFreelancerRepository : IRepository<Freelancer>
    {
        Freelancer GetFreelancerByIdentityId(string id);
    }
}