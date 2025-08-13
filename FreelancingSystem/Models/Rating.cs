using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreelancingSystem.Models
{
    public class Rating
    {   
        public int ReviewerId { get; set; }
        public int RevieweeId { get; set; }

        [ForeignKey(nameof(ReviewerId))]
        public User Reviewer { get; set; }
        [ForeignKey(nameof(RevieweeId))]
        public User Reviewee { get; set; }

        [Range(1, 5)]
        public int Rate { get; set; }
    }

}
