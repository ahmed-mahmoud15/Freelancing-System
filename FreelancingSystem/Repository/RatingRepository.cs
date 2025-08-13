using FreelancingSystem.Data;
using FreelancingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace FreelancingSystem.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly ApplicationDbContext context;

        public RatingRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddRating(Rating rating)
        {
            context.Ratings.Add(rating);
        }

        public void DeleteRating(int reviewerId, int revieweeId)
        {
            Rating rating = Get(reviewerId, revieweeId);
            context.Ratings.Remove(rating);
        }

        public IEnumerable<Rating> GetAllRatingsGivenBy(int reviewerId)
        {
            return context.Ratings.Where(r => r.ReviewerId  == reviewerId).Include(r => r.Reviewee).ToList();
        }

        public IEnumerable<Rating> GetAllRatingsUserGot(int revieweeId)
        {
            return context.Ratings.Where(r => r.RevieweeId == revieweeId).Include(r => r.Reviewer).ToList();
        }


        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateRating(Rating rating)
        {
            context.Ratings.Update(rating);
        }

        public int GetRating(int reviewerId, int revieweeId)
        {
            return Get(reviewerId, revieweeId)?.Rate ?? 0;
        }

        private Rating Get(int reviewerId, int revieweeId)
        {
            return context.Ratings.Where(r => r.ReviewerId == reviewerId && r.RevieweeId == revieweeId).SingleOrDefault();
        }
    }
}
