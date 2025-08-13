using Microsoft.AspNetCore.Mvc;
using FreelancingSystem.Models;
using FreelancingSystem.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IO;
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

            // Handle profile image upload
            if (ProfileImageFile != null && ProfileImageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                Directory.CreateDirectory(uploadsFolder);

                var fileName = $"{client.Id}_{Path.GetFileName(ProfileImageFile.FileName)}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ProfileImageFile.CopyToAsync(fileStream);
                }

                client.ProfileImagePath = "/images/" + fileName;
            }

            clientService.UpdateClient(client);

            TempData["SuccessMessage"] = "Profile updated successfully!";
            return RedirectToAction(nameof(Profile), new { id = client.Id });
        }
    }
}
