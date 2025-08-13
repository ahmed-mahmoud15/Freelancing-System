using FreelancingSystem.Models;

namespace FreelancingSystem.Service
{
    public interface IFreelancerService
    {
        // Freelancer CRUD
        IEnumerable<Freelancer> GetAllFreelancers();
        Freelancer GetFreelancerById(int id);
        Freelancer GetFreelancerByIdentity(string id);
        void AddFreelancer(Freelancer freelancer);
        void UpdateFreelancer(Freelancer freelancer);
        void DeleteFreelancer(int id);

        // Proposal management
        void AddProposal(int freelancerId, Proposal proposal);
        void DeleteProposal(int freelancerId, int proposalId);
    }
}
