using FreelancingSystem.Models;

namespace FreelancingSystem.Service
{
    public interface IFreelancerService
    {
        // Freelancer CRUD
        IEnumerable<Freelancer> GetAllFreelancers();
        Freelancer GetFreelancerById(int id);
        Freelancer GetFreelancerByIdentity(string id);
        void AddFreelancer(Freelancer freelancer, IFormFile file);
        void UpdateFreelancer(Freelancer freelancer, IFormFile file);
        void DeleteFreelancer(int id);

        // Proposal management
        void AddProposal(int freelancerId, Proposal proposal);
        void DeleteProposal(int freelancerId, int proposalId);
    }
}
