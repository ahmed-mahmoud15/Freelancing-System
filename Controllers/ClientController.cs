using Microsoft.AspNetCore.Mvc;
using FreelancingSystem.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace FreelancingSystem.Controllers
{
    public class ClientController : Controller
    {
        // Simulate data fetching and saving - replace with DB context
        private static Client _client = new Client
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            CompanyName = "Acme Corp",
            ProfileImagePath = "/images/default-profile.png",
            IdentityId = "identity-123",
        };

        // GET: Client/Profile
        public IActionResult Profile()
        {
            return View(_client);
        }

        // GET: Client/EditProfile
        public IActionResult EditProfile()
        {
            return View(_client);
        }

        // POST: Client/EditProfile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(Client model, IFormFile ProfileImageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Update client details
            _client.FirstName = model.FirstName;
            _client.LastName = model.LastName;
            _client.CompanyName = model.CompanyName;

            // Handle profile image upload
            if (ProfileImageFile != null && ProfileImageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                Directory.CreateDirectory(uploadsFolder);

                var fileName = $"{_client.Id}_{Path.GetFileName(ProfileImageFile.FileName)}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ProfileImageFile.CopyToAsync(fileStream);
                }

                _client.ProfileImagePath = "/images/" + fileName;
            }

            // In real app, save changes to DB here

            TempData["SuccessMessage"] = "Profile updated successfully!";
            return RedirectToAction(nameof(Profile));
        }
    }
}
