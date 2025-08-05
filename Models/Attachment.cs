using System.ComponentModel.DataAnnotations.Schema;

namespace FreelancingSystem.Models
{
    public class Attachment
    {  
        public int Id { get; set; }
        public string Name { get; set; }
        public string path { get; set; }

        [ForeignKey(nameof(Job))]
        public int JobId { get; set; }
        public Job Job { get; set; }

    }
}
