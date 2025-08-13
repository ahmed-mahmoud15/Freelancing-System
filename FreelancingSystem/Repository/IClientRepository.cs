using FreelancingSystem.Models;

namespace FreelancingSystem.Repository
{
    public interface IClientRepository : IRepository<Client>
    {
        Client GetClientByIdentityId(string id);
    }
}