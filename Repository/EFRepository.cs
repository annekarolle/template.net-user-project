using Microsoft.EntityFrameworkCore;
using StoreFIAP.Entity;
using StoreFIAP.Interface;
using static Dapper.SqlMapper;

namespace StoreFIAP.Repository
{
    public class EFRepository<T> : IRepository<T> where T : Entitys
    {

        protected ApplicationDbContext _context;
        protected DbSet<T> _dbSet;


        public EFRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public void Delete(int id)
        {
            _dbSet.Remove(GetById(id));
            _context.SaveChanges();
        }

        public IList<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.FirstOrDefault(t => t.Id == id);
        }

        public void Put(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Save(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }
    }
}
