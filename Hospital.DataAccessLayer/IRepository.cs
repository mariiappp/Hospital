using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hospital.Model;
namespace Hospital.DataAccessLayer
{
    public interface IRepository<T> where T : class, IDomainObject
    {
        T Add(T entity);
        bool Delete(int id);
        List<T> ReadAll();
        T? ReadById(int id);
        bool Update(T entity);
    }
}
