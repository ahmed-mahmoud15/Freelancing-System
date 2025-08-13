namespace FreelancingSystem.ViewModel
{
    public class ShowJobViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public float Budget {  get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
