using FreelancingSystem.Models;
using System.Collections.Generic;

namespace FreelancingSystem.Service
{
    public interface IProposalService
    {
        IEnumerable<Proposal> GetAllProposals();

        // Updated to use composite key
        Proposal GetProposalById(int jobId, int freelancerId);

        void AddProposal(Proposal proposal);

        void UpdateProposal(Proposal proposal);

        // Updated to use composite key
        void DeleteProposal(int jobId, int freelancerId);

        // Updated to use composite key
        void ApproveProposal(int jobId, int freelancerId, int clientId);

        // Updated to use composite key
        void RejectProposal(int jobId, int freelancerId, int clientId);
    }
}
