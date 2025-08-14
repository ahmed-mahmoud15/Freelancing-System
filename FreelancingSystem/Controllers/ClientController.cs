using Microsoft.AspNetCore.Mvc;
using FreelancingSystem.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using FreelancingSystem.Service;
using FreelancingSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace FreelancingSystem.Controllers
{
    //[Authorize(Roles = "Client")]
    public class ClientController : Controller
    {
        private readonly IClientService clientService;
        private readonly IJobService jobService;
        private readonly IProposalService proposalService;

        public ClientController(IClientService clientService, IJobService jobService, IProposalService proposalService)
        {
            this.clientService = clientService;
            this.jobService = jobService;
            this.proposalService = proposalService;
        }

        public IActionResult JobDetails(int id)
        {
            var result = proposalService.GetAllFreelancersAppliedFor(id)
                .Select(e => new ShowFreelancerProposalViewModel()
                {
                    Id = e.FreelancerId,
                    JobId = e.JobId,
                    Name = e.Freelancer.FirstName + " " + e.Freelancer.LastName,
                    Bid = e.Bid,
                    CoverLetter = e.CoverLetter,
                    Status = e.Status.GetValueOrDefault()
                });
            return View(result);
        }

        public IActionResult Hire(int jobId, int freelancerId)
        {
            proposalService.ApproveProposal(jobId, freelancerId);
            return RedirectToAction("JobDetails", new {id = jobId});
        }

        public IActionResult Reject(int jobId, int freelancerId)
        {
            proposalService.RejectProposal(jobId, freelancerId);
            return RedirectToAction("JobDetails", new { id = jobId });
        }
        public IActionResult AddJob()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddJob(AddJobViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Job job = new Job()
            {
                ClientId = int.Parse(User.FindFirst("UserId")?.Value),
                CreatedAt = DateTime.Now,
                Title = model.Name,
                Description = model.Description,
                Budget = model.Budget
            };
            jobService.AddJob(job);
            return RedirectToAction(nameof(Profile), new { id = User.FindFirst("UserId").Value });
        }

        // GET: Client/Profile/1
        public async Task<IActionResult> Profile(int id)
        {
            if (!int.TryParse(User.FindFirst("UserId")?.Value, out var loggedInUserId))
            {
                return Unauthorized();
            }

            // If the ID in the URL does not match the logged-in user's ID → Unauthorized
            if (id != loggedInUserId)
            {
                return Unauthorized();
            }

            var client = clientService.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }
            var jobsByClient = jobService.GetJobsByClinetId(id)
                .Select(x => new ShowJobViewModel()
                {
                    Name = x.Title,
                    Id = x.Id,
                    Budget = x.Budget,
                    CreatedAt = x.CreatedAt,
                    Description = x.Description
                });

            ClientProfileViewModel profile = new ClientProfileViewModel()
            {
                Id = id,
                Name = client.FirstName + " " + client.LastName,
                Company = client.CompanyName,
                PhotoPath = client.ProfileImagePath,
                Jobs = jobsByClient
            };
            return View(profile);
        }

        // GET: Client/EditProfile/1
        public async Task<IActionResult> EditProfile(int id)
        {
            var client = clientService.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(EditClientViewModel.ToEditClient(client));
        }

        // POST: Client/EditProfile/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(int id, EditClientViewModel model, IFormFile ProfileImageFile)
        {
            if (id != model.Id)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ModelState.Values.ToString());
                return View(model);
            }

            var client = clientService.GetClientById(id);
            if (client == null)
                return NotFound();

            client = EditClientViewModel.ToClient(client, model);

            // my edit: moved image handling to service
            clientService.UpdateClient(client, ProfileImageFile);

            TempData["SuccessMessage"] = "Profile updated successfully!";
            return RedirectToAction(nameof(Profile), new { id = client.Id });
        }
    }
}
