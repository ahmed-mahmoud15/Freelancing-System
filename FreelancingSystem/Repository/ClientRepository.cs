using FreelancingSystem.Data;
using FreelancingSystem.Models;

namespace FreelancingSystem.Repository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {

        public ClientRepository(ApplicationDbContext context) : base(context) { }

        public Client GetClientByIdentityId(string id)
        {
            return table.FirstOrDefault(e => e.IdentityId.Equals(id));
        }
    }
}