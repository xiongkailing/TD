using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamDay.DAL;

namespace TeamDay.Testor
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new TestDbContext())
            {
                IRepository<KeyValue> repository = new EfRepository<KeyValue>(context);
                var entity = repository.GetByKey(2);
                entity.Value = "female";
                repository.Update(entity);
                repository.Dispose();
            }
        }
    }
}
