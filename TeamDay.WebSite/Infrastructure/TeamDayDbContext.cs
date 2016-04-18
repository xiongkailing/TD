using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Web;

namespace TeamDay.WebSite.Infrastructure
{
    public class TeamDayDbContext : DbContext
    {
        public TeamDayDbContext()
            : base("name=TeamDayDbContext")
        { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.Load("TeamDay.EntityFrameworkOrm").GetTypes()
                .Where(type => !String.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                    && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            //Database.SetInitializer<TeamDayDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}