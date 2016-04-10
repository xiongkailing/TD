using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamDay.Models.EfModels;

namespace TeamDay.DAL
{
    public class EfRepository<T> : IRepository<T> where T : EfBaseModel
    {
        private readonly DbContext dbContainor;
        public EfRepository(DbContext dbContainor)
        {
            this.dbContainor = dbContainor;
        }
        public void Update(T entity,bool isSave=true)
        {
            entity.LastUpdateTime = DateTime.Now;
            dbContainor.Entry<T>(entity).State = EntityState.Modified;
            if(isSave)
                dbContainor.SaveChanges();
        }

        public void Add(T entity,bool isSave=true)
        {
            entity.CreateTime = DateTime.Now;
            dbContainor.Entry<T>(entity).State = EntityState.Added;
            if (isSave)
                dbContainor.SaveChanges();
        }

        public void Delete(int Id,bool isPhysic=false,bool isSave=true)
        {
            T entity = dbContainor.Set<T>().Find(Id);
            if (entity == null)
                throw new KeyNotFoundException();
            if (isPhysic)
                dbContainor.Entry<T>(entity).State = EntityState.Deleted;
            else
            {
                entity.DeleteTime = DateTime.Now;
                entity.IsDeleted = true;
                dbContainor.Entry<T>(entity).State = EntityState.Modified;
            }
            if (isSave)
                dbContainor.SaveChanges();

        }

        public IQueryable<T> Get()
        {
            return dbContainor.Set<T>().Where(t => t.IsDeleted);
        }

        public T GetByKey(int id)
        {
            return dbContainor.Set<T>().SingleOrDefault(t => t.Id == id && !t.IsDeleted);
        }


        public IQueryable<T> GetWithSoftDelete()
        {
            return dbContainor.Set<T>();
        }

        public T GetByKeyWithSoftDelete(int id)
        {
            return dbContainor.Set<T>().SingleOrDefault(t => t.Id == id);
        }


        public void Dispose()
        {
            dbContainor.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
