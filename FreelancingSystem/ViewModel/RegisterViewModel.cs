using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace FreelancingSystem.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Upload)]
        public string? PhotoPath { get; set; }

        public RoleViewModel Role { get; set; }

        [Display(Name = "Freelancer's Bio")]
        public string? FreelancerBio { get; set; }

        [Display(Name = "Company Name")]
        public string? ClientCompanyName { get; set; }
    }

    public enum RoleViewModel
    {
        Freelancer,
        Client
    }
}
