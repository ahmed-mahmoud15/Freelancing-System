using FreelancingSystem.Models;
using FreelancingSystem.Repository;

namespace FreelancingSystem.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void AddUser(User user)
        {
            userRepository.Insert(user);
            userRepository.Save();
        }

        public void DeleteUser(int id)
        {
            userRepository.Delete(id);
            userRepository.Save();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return userRepository.GetAll();
        }

        public User GetUserById(int id)
        {
            return userRepository.GetById(id);
        }

        public User GetUserByIdentity(string id)
        {
            return userRepository.GetUserByIdentityId(id);
        }

        public void UpdateUser(User user)
        {
            userRepository.Update(user);
            userRepository.Save();
        }
    }
}
