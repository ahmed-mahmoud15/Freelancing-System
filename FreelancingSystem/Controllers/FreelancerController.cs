using FreelancingSystem.Models;
using FreelancingSystem.Service;
using FreelancingSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FreelancingSystem.Controllers
{
    public class FreelancerController : Controller
    {
        private readonly IFreelancerService freelancerService;
        private readonly IProposalService proposalService;
        private readonly IJobService jobService;

        public FreelancerController(IFreelancerService freelancerService, IProposalService proposalService, IJobService jobService)
        {
            this.freelancerService = freelancerService;
            this.proposalService = proposalService;
            this.jobService = jobService;
        }

        public IActionResult Apply(int freelancerId, int jobId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Apply(CreateProposalViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Proposal proposal = new Proposal() { 
                Bid = model.Bid,
                CoverLetter = model.CoverLetter,
                Date = DateTime.UtcNow,
                Status = Status.Applied,
                FreelancerId = model.FreelancerId,
                JobId = model.JobId
            };
            proposalService.AddProposal(proposal);
            return RedirectToAction(nameof(Profile), new { id = proposal.FreelancerId});
        }

        public IActionResult JobSearch()
        {
            int freelancerId = int.Parse(User.FindFirst("UserId").Value);
            var jobs = jobService.GetJobsNotAppliedByFreelancer(freelancerId).Select(x => new ShowJobViewModel()
            {
                Id = x.Id,
                Name = x.Title,
                Description = x.Description,
                Budget = x.Budget,
                CreatedAt = x.CreatedAt
            });
            return View(jobs);
        }

        public IActionResult ProposalDetails(int freelancerId, int jobId)
        {
            var proposal = proposalService.GetProposalById(jobId, freelancerId);
            if(proposal == null)
            {
                return NotFound();
            }
            return View(proposal);
        }

        public IActionResult Profile(int id)
        {
            var freelancer = freelancerService.GetFreelancerById(id);
            if (freelancer == null) { 
                return NotFound();
            }

            var proposalsByFreelancer = proposalService.GetAllJobsForFreelancer(id)
                .Select(x => new ShowFreelancerProposalViewModel()
                {
                    Bid = x.Bid,
                    CoverLetter = x.CoverLetter,
                    Name = x.Job.Title,
                    Status = x.Status.GetValueOrDefault(),
                    Id = id,
                    JobId = x.JobId
                });

            FreelancerProfileViewModel profil = new FreelancerProfileViewModel() { 
                Id = id,
                Name = freelancer.FirstName + " " + freelancer.LastName,
                PhotoPath = freelancer.ProfileImagePath,
                Bio = freelancer.Bio,
                Proposals = proposalsByFreelancer
            };
            return View(profil);
        }


        public async Task<IActionResult> EditProfile(int id)
        {
            var freelancer = freelancerService.GetFreelancerById(id);
            if (freelancer == null)
            {
                return NotFound();
            }
            return View(EditFreelancerViewModel.ToEditFreelancer(freelancer));
        }

        // POST: Client/EditProfile/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(int id, EditFreelancerViewModel model, IFormFile ProfileImageFile)
        {
            if (id != model.Id)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ModelState.Values.ToString());
                return View(model);
            }

            var freelancer = freelancerService.GetFreelancerById(id);
            if (freelancer == null)
                return NotFound();

            freelancer = EditFreelancerViewModel.ToFreelancer(freelancer, model);

            // my edit: moved image handling to service
            freelancerService.UpdateFreelancer(freelancer, ProfileImageFile);

            TempData["SuccessMessage"] = "Profile updated successfully!";
            return RedirectToAction(nameof(Profile), new { id = freelancer.Id });
        }
    }
}
