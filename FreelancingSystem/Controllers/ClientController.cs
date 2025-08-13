using Microsoft.AspNetCore.Mvc;
using FreelancingSystem.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using FreelancingSystem.Service;
using FreelancingSystem.ViewModel;

namespace FreelancingSystem.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService clientService;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        // GET: Client/Profile/1
        public async Task<IActionResult> Profile(int id)
        {
            var client = clientService.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
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
