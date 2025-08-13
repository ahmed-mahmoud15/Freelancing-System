using FreelancingSystem.Models;

namespace FreelancingSystem.Repository
{
    public interface IRatingRepository
    {

        int GetRating(int reviewerId, int revieweeId);

        IEnumerable<Rating> GetAllRatingsGivenBy(int reviewerId);

        IEnumerable<Rating> GetAllRatingsUserGot(int revieweeId);

        void AddRating(Rating rating);
        void UpdateRating(Rating rating);
        void DeleteRating(int reviewerId, int revieweeId);

        void Save();

    }
}
