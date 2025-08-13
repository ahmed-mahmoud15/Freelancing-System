using FreelancingSystem.Models;

namespace FreelancingSystem.Service
{
    public interface IRatingService
    {
        void Rate(int reviewerId, int revieweeId, int rate);

        bool ChangeRate(int reviewerId, int revieweeId, int rate);

        double GetAverageRate(int revieweeId);

        IEnumerable<Rating> GetAllRatingsBy(int id);

        IEnumerable<Rating> GetAllRatingsFor(int id);
    }
}
