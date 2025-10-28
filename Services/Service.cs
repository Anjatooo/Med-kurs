using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Services.BD;

namespace WebApplication3.Services
{
    public interface IRepositoty<T>
    {
        IEnumerable<T> GetCustomers();
        T GetId (int id);
        void AddValue(T value);
        void RemoveValue(int valueId);
        void UpdateValue(T value);
        void Save();


    }
    public class Repository<T> : IRepositoty<T> where T : class 
    {
        ApplicationContext context_;
        private DbSet<T> dbset_;
        public Repository(ApplicationContext context)
        {
            context_ = context;
            dbset_ = context_.Set<T>();
        }
        public IEnumerable<T> GetCustomers()
        {
            return dbset_.ToList();
        }
        public T GetId (int id)
        {
            return dbset_.Find(id);
        }
        public void AddValue(T value)
        {
            
            dbset_.Add(value);
        }
        public void RemoveValue(int id)
        {
            var value = dbset_.Find(id);
            if (value != null)
            {
                dbset_.Remove(value);
            }
        }
        public void UpdateValue(T value)
        {
            dbset_.Update(value);
        }
        public void Save()
        {
            context_.SaveChanges();
        }
    }

}
