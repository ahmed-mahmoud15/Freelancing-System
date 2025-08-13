using FreelancingSystem.Models;
using FreelancingSystem.Repository;
using Microsoft.AspNetCore.Http; // my edit: for IFormFile
using System.IO;                 // my edit: for Path, FileStream

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
        
        public void AddClient(Client client, IFormFile file)
        {
            HandleProfileImageUpload(client, file);
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

        public void UpdateClient(Client client, IFormFile file)
        {
            HandleProfileImageUpload(client, file);
            clientRepository.Update(client);
            clientRepository.Save();
        }

        private void HandleProfileImageUpload(Client client, IFormFile profileImageFile)
        {
            if (profileImageFile != null && profileImageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                Directory.CreateDirectory(uploadsFolder);

                var fileName = $"{client.Id}_{Path.GetFileName(profileImageFile.FileName)}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    profileImageFile.CopyTo(fileStream);
                }

                client.ProfileImagePath = "/images/" + fileName;
            }
        }

        // ---------------- Jobs ----------------
        public void AddJob(Job job)
        {
            if (job == null)
                throw new ArgumentNullException(nameof(job));

            throw new NotImplementedException("Implement AddJob logic with proper repository/service.");
        }
    }
}
