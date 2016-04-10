using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDay.DAL
{
    public interface IRepository<T> : IDisposable
    {
        void Update(T entity, bool isSave = true);
        void Add(T entity, bool isSave = true);
        void Delete(int Id, bool isPhysic = false, bool isSave = true);
        IQueryable<T> Get();
        T GetByKey(int id);
        IQueryable<T> GetWithSoftDelete();
        T GetByKeyWithSoftDelete(int id);
    }
}