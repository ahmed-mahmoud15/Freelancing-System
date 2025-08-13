using FreelancingSystem.Models;
using FreelancingSystem.Repository;

namespace FreelancingSystem.Service
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            this.ratingRepository = ratingRepository;
        }

        public bool ChangeRate(int reviewerId, int revieweeId, int rate)
        {

            if (rate < 0 || rate > 5)
            {
                return false;
            }

            Rating rating = new Rating()
            {
                ReviewerId = reviewerId,
                RevieweeId = revieweeId,
                Rate = rate
            };
            ratingRepository.UpdateRating(rating);
            return true;
        }

        public IEnumerable<Rating> GetAllRatingsBy(int id)
        {
            return ratingRepository.GetAllRatingsGivenBy(id);
        }

        public IEnumerable<Rating> GetAllRatingsFor(int id)
        {
            return ratingRepository.GetAllRatingsUserGot(id);
        }

        public double GetAverageRate(int revieweeId)
        {
            var ratings =  ratingRepository.GetAllRatingsUserGot(revieweeId).Select(r => r.Rate);
            return ratings.Any() ? ratings.Average() : 0;
        }

        public void Rate(int reviewerId, int revieweeId, int rate)
        {
            if(revieweeId == reviewerId)
            {
                throw new Exception("User Can't Rate himself");
            }
            if(rate < 0 || rate > 5)
            {
                throw new Exception("Rate must be between 1 and 5");
            }
            Rating rating = new Rating() { 
                ReviewerId = reviewerId,
                RevieweeId = revieweeId,
                Rate = rate
            };
            ratingRepository.AddRating(rating);
        }
    }
}
