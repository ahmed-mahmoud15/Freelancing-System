namespace FreelancingSystem.ViewModel
{
    public class ClientProfileViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Company {  get; set; }

        public string PhotoPath { get; set; }

        public IEnumerable<ShowJobViewModel> Jobs { get; set; }
    }
}
