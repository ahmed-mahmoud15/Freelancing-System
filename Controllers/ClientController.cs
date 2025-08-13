using Microsoft.AspNetCore.Mvc;
using FreelancingSystem.Models;
using FreelancingSystem.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;

namespace FreelancingSystem.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Client/Profile/1
        public async Task<IActionResult> Profile(int id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // GET: Client/EditProfile/1
        public async Task<IActionResult> EditProfile(int id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Client/EditProfile/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(int id, Client model, IFormFile ProfileImageFile)
        {
            if (id != model.Id)
                return BadRequest();

            if (!ModelState.IsValid)
            {   
                return View(model);
            }

            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
            if (client == null)
                return NotFound();

            // Update client details
            client.FirstName = model.FirstName;
            client.LastName = model.LastName;
            client.CompanyName = model.CompanyName;

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

            _context.Update(client);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Profile updated successfully!";
            return RedirectToAction(nameof(Profile), new { id = client.Id });
        }
    }
}
