using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
namespace FreelancingSystem.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }

        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public float Budget { get; set; }

        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? Deadline { get; set; }

        public Client Client { get; set; }

        public ICollection<JobSkill> Skills { get; set; } = new List<JobSkill>();

        public ICollection<JobCategory> Categories { get; set; } = new List<JobCategory>();
        public ICollection<JobTag> Tags { get; set; } = new List<JobTag>();
        public ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
    }
}
