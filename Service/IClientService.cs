using FreelancingSystem.Models;

namespace FreelancingSystem.Service
{
    public interface IClientService
    {
        // Client CRUD
        IEnumerable<Client> GetAllClients();
        Client GetClientById(int id);
        Client GetClientByIdentity(string id);
        void AddClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(int id);

        // Job Categories
        IEnumerable<JobCategory> GetJobCategoriesForClient(int clientId);
        void AssignJobCategoryToClient(int clientId, int categoryId);
        void RemoveJobCategoryFromClient(int clientId, int categoryId);

        // Job Skills
        IEnumerable<JobSkill> GetJobSkillsForClient(int clientId);
        void AssignJobSkillToClient(int clientId, int skillId);
        void RemoveJobSkillFromClient(int clientId, int skillId);
        // Jobs
        void AddJob(Job job);
    }
}
