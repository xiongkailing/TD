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
        private readonly IRedisClientsManager _redisClientsManger;
        private readonly int _id;
        public RedisRepository(IRedisClientsManager redisClientsManger, int id)
        {
            _redisClientsManger = redisClientsManger;
            _id = id;
        }
        public void Update(T entity, bool isSave = false, DateTime? expireTime = null)
        {
            using (var client = _redisClientsManger.GetClient())
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
            using (var client = _redisClientsManger.GetClient())
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
            using (IRedisClient client = _redisClientsManger.GetClient())
            {
                client.Db = _id;
                client.Remove(Id);
            }

        }

        public IEnumerable<T> Get()
        {
            using (IRedisClient client = _redisClientsManger.GetClient())
            {
                client.Db = _id;
                var keys = client.GetAllKeys();
                var data = client.GetAll<T>(keys);
                return data.Values;
            }
        }

        public T GetByKey(string id)
        {
            using (IRedisClient client = _redisClientsManger.GetClient())
            {
                client.Db = _id;
                return client.Get<T>(id);
            }
        }
        public void Dispose()
        {
            _redisClientsManger.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
