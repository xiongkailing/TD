using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDay.DAL
{
    public interface IRedisRepository<T> : IDisposable
    {
        void Update(T entity, bool isSave = false, DateTime? expireTime = null);
        void Add(T entity, bool isSave = false, DateTime? expireTime = null);
        void Delete(string Id);
        IEnumerable<T> Get();
        T GetByKey(string id);
    }
}
