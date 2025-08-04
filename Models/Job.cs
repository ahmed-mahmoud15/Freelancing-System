using System;
namespace FreelancingSystem.Models
{
    public class Job
    { 
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Budget { get; set; }
        public DateTime  deadline { get; set; }


        public ICollection<JobSkill> Skills { get; set; }

        public ICollection<JobCategory> Categories { get; set; }
        public ICollection<JobTag> Tags { get; set; }
        public ICollection<Attachment> Attachments { get; set; }


    }
}
