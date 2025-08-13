using FreelancingSystem.Models;

namespace FreelancingSystem.ViewModel
{
    public class EditFreelancerViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Bio { get; set; }

        public string? ProfileImagePath { get; set; }

        public static Freelancer ToFreelancer(Freelancer freelancer, EditFreelancerViewModel model)
        {
            freelancer.FirstName = model.FirstName;
            freelancer.LastName = model.LastName;
            freelancer.Bio = model.Bio;
            freelancer.ProfileImagePath = model.ProfileImagePath;
            return freelancer;
        }

        public static EditFreelancerViewModel ToEditFreelancer(Freelancer freelancer)
        {
            return new EditFreelancerViewModel()
            {
                Id = freelancer.Id,
                FirstName = freelancer.FirstName,
                LastName = freelancer.LastName,
                Bio = freelancer.Bio,
                ProfileImagePath = freelancer.ProfileImagePath
            };
        }
    }
}
