using FreelancingSystem.Models;
using FreelancingSystem.Repository;

namespace FreelancingSystem.Service
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IJobCategoryService _jobCategoryService;
        private readonly IJobSkillService _jobSkillService;

        public ClientService(
            IClientRepository clientRepository,
            IJobCategoryService jobCategoryService,
            IJobSkillService jobSkillService)
        {
            _clientRepository = clientRepository;
            _jobCategoryService = jobCategoryService;
            _jobSkillService = jobSkillService;
        }

        // ---------------- Client CRUD ----------------
        public IEnumerable<Client> GetAllClients() => _clientRepository.GetAll();

        public Client GetClientById(int id) => _clientRepository.GetById(id);

        public Client GetClientByIdentity(string id) => _clientRepository.GetClientByIdentityId(id);

        public void AddClient(Client client) => _clientRepository.Add(client);

        public void UpdateClient(Client client) => _clientRepository.Update(client);

        public void DeleteClient(int id) => _clientRepository.Delete(id);

        // ---------------- Job Categories ----------------
        public IEnumerable<JobCategory> GetJobCategoriesForClient(int clientId)
        {
            var client = _clientRepository.GetById(clientId);
            return client?.JobCategories ?? Enumerable.Empty<JobCategory>();
        }

        public void AssignJobCategoryToClient(int clientId, int categoryId)
        {
            var client = _clientRepository.GetById(clientId);
            var category = _jobCategoryService.GetJobCategoryById(categoryId);

            if (client != null && category != null && !client.JobCategories.Contains(category))
            {
                client.JobCategories.Add(category);
                _clientRepository.Update(client);
            }
        }

        public void RemoveJobCategoryFromClient(int clientId, int categoryId)
        {
            var client = _clientRepository.GetById(clientId);
            var category = client?.JobCategories.FirstOrDefault(c => c.Id == categoryId);

            if (client != null && category != null)
            {
                client.JobCategories.Remove(category);
                _clientRepository.Update(client);
            }
        }

        // ---------------- Job Skills ----------------
        public IEnumerable<JobSkill> GetJobSkillsForClient(int clientId)
        {
            var client = _clientRepository.GetById(clientId);
            return client?.JobSkills ?? Enumerable.Empty<JobSkill>();
        }

        public void AssignJobSkillToClient(int clientId, int skillId)
        {
            var client = _clientRepository.GetById(clientId);
            var skill = _jobSkillService.GetJobSkillById(skillId);

            if (client != null && skill != null && !client.JobSkills.Contains(skill))
            {
                client.JobSkills.Add(skill);
                _clientRepository.Update(client);
            }
        }

        public void RemoveJobSkillFromClient(int clientId, int skillId)
        {
            var client = _clientRepository.GetById(clientId);
            var skill = client?.JobSkills.FirstOrDefault(s => s.Id == skillId);

            if (client != null && skill != null)
            {
                client.JobSkills.Remove(skill);
                _clientRepository.Update(client);
            }
        }


        // ... existing methods

        // Jobs
        public void AddJob(Job job)
        {
            if (job == null)
                throw new ArgumentNullException(nameof(job));

            _context.Jobs.Add(job);
            _context.SaveChanges();
        }
    }
}
