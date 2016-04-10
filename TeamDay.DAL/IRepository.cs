using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDay.DAL
{
    public interface IRepository<T>
    {
        void Update(T entity);
        void Add(T entity);
        void Delete(object Id);
        IQueryable<T> Get();
        T GetByKey(object id);
    }
}