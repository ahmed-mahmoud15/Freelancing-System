using FreelancingSystem.Models;
using System.Collections.Generic;

namespace FreelancingSystem.Repository
{
    public interface IJobCategoryRepository
    {
        IEnumerable<JobCategory> GetAll();
        JobCategory GetByIds(int jobId, int categoryId);
        void Insert(JobCategory jobCategory);
        void Update(JobCategory jobCategory);
        void Delete(int jobId, int categoryId);
        void Save();
    }
}
