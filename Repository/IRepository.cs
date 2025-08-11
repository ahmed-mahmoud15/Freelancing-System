namespace FreelancingSystem.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T record);
        void Update(T record);
        void Delete(object id);
        void Save();
    }
}
