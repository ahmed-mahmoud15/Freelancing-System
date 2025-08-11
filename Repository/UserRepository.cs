using FreelancingSystem.Data;
using FreelancingSystem.Models;

namespace FreelancingSystem.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository(ApplicationDbContext context) : base(context) { }

        public User GetUserByIdentityId(string id)
        {
            return table.FirstOrDefault(e => e.IdentityId.Equals(id));
        }
    }
}
