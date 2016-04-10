using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamDay.Models.RedisModels;

namespace TeamDay.DAL
{
    public class RedisRepository<T>:IRepository<T> where T:RedisBaseModel
    {
        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Get()
        {
            throw new NotImplementedException();
        }

        public T GetByKey(object id)
        {
            throw new NotImplementedException();
        }
    }
}
