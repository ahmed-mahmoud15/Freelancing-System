using FreelancingSystem.Models;

namespace FreelancingSystem.Service
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);

        User GetUserByIdentity(string id);

        void AddUser(User user);

        void UpdateUser(User user);

        void DeleteUser(int id);
    }
}
