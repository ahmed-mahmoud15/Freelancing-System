using FreelancingSystem.Models;
using FreelancingSystem.Repository;

namespace FreelancingSystem.Service
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        // ---------------- Client CRUD ----------------
        public void AddClient(Client client)
        {
            clientRepository.Insert(client);
            clientRepository.Save();
        }

        public void DeleteClient(int id)
        {
            clientRepository.Delete(id);
            clientRepository.Save();
        }

        public IEnumerable<Client> GetAllClients()
        {
            return clientRepository.GetAll();
        }

        public Client GetClientById(int id)
        {
            return clientRepository.GetById(id);
        }

        public Client GetClientByIdentity(string id)
        {
            return clientRepository.GetClientByIdentityId(id);
        }

        public void UpdateClient(Client client)
        {
            clientRepository.Update(client);
            clientRepository.Save();
        }

        // ---------------- Jobs ----------------
        public void AddJob(Job job)
        {
            if (job == null)
                throw new ArgumentNullException(nameof(job));

            // Assuming you will inject and use a JobRepository or service instead of context here
            throw new NotImplementedException("Implement AddJob logic with proper repository/service.");
        }
    }
}
