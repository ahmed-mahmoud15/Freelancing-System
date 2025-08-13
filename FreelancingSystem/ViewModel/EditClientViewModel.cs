using FreelancingSystem.Models;

namespace FreelancingSystem.ViewModel
{
    public class EditClientViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CompanyName { get; set; }

        public string? ProfileImagePath { get; set; }

        public static Client ToClient (Client client, EditClientViewModel model)
        {
            client.FirstName = model.FirstName;
            client.LastName = model.LastName;
            client.CompanyName = model.CompanyName;
            client.ProfileImagePath = model.ProfileImagePath;
            return client;
        }

        public static EditClientViewModel ToEditClient(Client client)
        {
            return new EditClientViewModel()
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                CompanyName = client.CompanyName,
                ProfileImagePath = client.ProfileImagePath
            };
        }
    }
}
