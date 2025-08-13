using FreelancingSystem.Service;
using FreelancingSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FreelancingSystem.Controllers
{
    public class FreelancerController : Controller
    {
        private readonly IFreelancerService freelancerService;
        private readonly IProposalService proposalService;

        public FreelancerController(IFreelancerService freelancerService, IProposalService proposalService)
        {
            this.freelancerService = freelancerService;
            this.proposalService = proposalService;
        }

        public IActionResult Profile(int id)
        {
            //var freelancer = freelancerService.GetFreelancerById(id);
            //if (freelancer == null) { 
            //    return NotFound();
            //}

            //var jobsByClient = proposalService.GetJobsByClinetId(id)
            //    .Select(x => new ShowFreelancerProposalViewModel()
            //    {
                    
            //    });

            //FreelancerProfileViewModel profil = new FreelancerProfileViewModel() { 
            //    Id = id,
            //    Name = freelancer.FirstName + " " + freelancer.LastName,
            //    PhotoPath = freelancer.ProfileImagePath,
            //    Bio = freelancer.Bio,
            //    Proposals = 
            //};
            return View();
        }
    }
}
