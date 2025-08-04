namespace FreelancingSystem.Models
{
    public class Rating
    {
        [ForeignKey(nameof(Client))]
        public int ReviwerId { get; set; }
        [ForeignKey(nameof(Freelancer))]
        public int ReviweeId { get; set; }


        public Client Client { get; set; }
        public Freelancer Freelancer { get; set; }

        public int rate { get; set; }

    }

}
