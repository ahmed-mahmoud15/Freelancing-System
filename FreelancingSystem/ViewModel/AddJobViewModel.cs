namespace FreelancingSystem.ViewModel
{
    public class AddJobViewModel
    {
        public int Id { get; set; }

        public int ClinetId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Budget { get; set; }
    }
}
