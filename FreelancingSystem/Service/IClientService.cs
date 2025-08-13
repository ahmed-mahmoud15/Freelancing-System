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

        // Jobs
        void AddJob(Job job);
    }
}
