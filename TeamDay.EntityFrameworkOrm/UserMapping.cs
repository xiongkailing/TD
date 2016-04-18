using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamDay.Models.EfModels;

namespace TeamDay.EntityFrameworkOrm
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            this.ToTable("User");
            this.HasKey(t => t.Id);
            this.Property(t => t.CreateTime).IsRequired();
            this.Property(t => t.DeleteTime).IsOptional();
            this.Property(t => t.LastUpdateTime).IsOptional();
            this.Property(t => t.Phone).IsOptional().HasMaxLength(11).IsFixedLength();
            this.Property(t => t.Password).HasMaxLength(32).IsFixedLength().IsRequired();
            this.Property(t => t.LoginName).IsRequired();
            this.Property(t => t.Name).IsRequired();
            this.Property(t => t.Email).IsRequired().HasMaxLength(100);
            this.Property(t => t.Code).IsRequired().HasMaxLength(20).IsFixedLength();
            this.Property(t => t.LastLoginTime).IsRequired();
            this.HasRequired(t => t.Point).WithRequiredPrincipal(p => p.User);
        }
    }
}
