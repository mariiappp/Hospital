using Hospital.Model;
using Microsoft.EntityFrameworkCore;

namespace Hospital.DataAccessLayer.EF
{
    public class EntityRepository<T> : IRepository<T>
        where T : class, IDomainObject
    {
        private readonly DBContext _context;

        public EntityRepository()
        {
            _context = new DBContext();
            _context.Database.EnsureCreated();
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public bool Delete(int id)
        {
            var entity = _context.Set<T>()
                .FirstOrDefault(x => x.Id == id);

            if (entity == null)
                return false;

            _context.Set<T>().Remove(entity);
            _context.SaveChanges();

            return true;
        }

        public List<T> ReadAll()
        {
            return _context.Set<T>()
                .AsNoTracking()
                .ToList();
        }

        public T? ReadById(int id)
        {
            return _context.Set<T>()
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }

        public bool Update(T entity)
        {
            var existingEntity = _context.Set<T>()
                .FirstOrDefault(x => x.Id == entity.Id);

            if (existingEntity == null)
                return false;

            _context.Entry(existingEntity)
                .CurrentValues
                .SetValues(entity);

            _context.SaveChanges();

            return true;
        }
    }
}