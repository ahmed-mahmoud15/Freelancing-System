using FreelancingSystem.Models;

namespace FreelancingSystem.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByIdentityId(string id);
    }
}
