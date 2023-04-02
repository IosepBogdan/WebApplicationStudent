using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppStudent.Data.Repository.BaseRepository
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IQueryable<T> GetQuery();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void AddRange (IEnumerable<T> entities);
        void DeleteRange (IEnumerable<T> entities);
    }
}
