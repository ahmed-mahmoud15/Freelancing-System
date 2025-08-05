namespace FreelancingSystem.Models
{
    public class Rating
    {   
        public int ReviewerId { get; set; }
        public int RevieweeId { get; set; }
        public User Reviewer { get; set; }
        public User Reviewee { get; set; }
        public int rate { get; set; }


    }

}
