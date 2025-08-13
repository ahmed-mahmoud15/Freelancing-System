namespace FreelancingSystem.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<JobTag> Jobs { get; set; } = new List<JobTag>();

    }
}
