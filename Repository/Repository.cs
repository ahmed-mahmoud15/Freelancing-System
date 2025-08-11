
using FreelancingSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace FreelancingSystem.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        protected readonly DbSet<T> table;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            this.table = context.Set<T>();
        }

        public void Delete(object id)
        {
            T? entity = table.Find(id);
            if (entity != null)
            {
                table.Remove(entity);
            }
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T record)
        {
            table.Add(record);
        }

        public void SaveAsync()
        {
            context.SaveChanges();
        }

        public void Update(T record)
        {
            table.Attach(record);
            context.Entry(record).State = EntityState.Modified;
        }
    }
}
