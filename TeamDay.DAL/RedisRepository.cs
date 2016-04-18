using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamDay.Models.RedisModels;

namespace TeamDay.DAL
{
    public class RedisRepository<T> : IRedisRepository<T> where T : RedisBaseModel
    {
        protected readonly IRedisClientsManager redisClientsManger;
        private readonly int _id;
        public RedisRepository(IRedisClientsManager redisClientsManger, int id)
        {
            this.redisClientsManger = redisClientsManger;
            this._id = id;
        }
        public void Update(T entity, bool isSave = false, DateTime? expireTime = null)
        {
            using (var client = redisClientsManger.GetClient())
            {
                client.Db = _id;
                if (expireTime == null)
                    client.Set<T>(entity.Id, entity);
                else
                {
                    var date = (DateTime)expireTime;
                    client.Set<T>(entity.Id, entity, date);
                }
                if (isSave)
                    client.Save();
            }
        }

        public void Add(T entity, bool isSave = false, DateTime? expireTime = null)
        {
            using (var client = redisClientsManger.GetClient())
            {
                client.Db = _id;
                if (expireTime == null)
                    client.Set<T>(entity.Id, entity);
                else
                {
                    var date = (DateTime)expireTime;
                    client.Set<T>(entity.Id, entity, date);
                }
                if (isSave)
                    client.Save();
            }
        }

        public void Delete(string Id)
        {
            using (IRedisClient client = redisClientsManger.GetClient())
            {
                client.Db = _id;
                client.Remove(Id);
            }

        }

        public IEnumerable<T> Get()
        {
            using (IRedisClient client = redisClientsManger.GetClient())
            {
                client.Db = _id;
                var keys = client.GetAllKeys();
                var data = client.GetAll<T>(keys);
                return data.Values;
            }
        }

        public T GetByKey(string id)
        {
            using (IRedisClient client = redisClientsManger.GetClient())
            {
                client.Db = _id;
                return client.Get<T>(id);
            }
        }
        public void Dispose()
        {
            redisClientsManger.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
