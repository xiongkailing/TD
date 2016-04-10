using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDay.Testor
{
    public class TestDbContext:DbContext
    {
        public DbSet<KeyValue> KeyValues { get; set; }
        public TestDbContext()
            : base("name=TestDbContext")
        {
        }
    }
}
