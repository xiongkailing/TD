using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamDay.Models;
using TeamDay.Models.EfModels;

namespace TeamDay.EntityFrameworkOrm
{
    public class RewardPointMapping : EntityTypeConfiguration<RewardPoint>
    {
        public RewardPointMapping()
        {
            this.ToTable("RewardPoints");
            this.HasKey(t => t.Id);
            this.Property(t => t.CreateTime).IsRequired();
            this.Property(t => t.DeleteTime).IsOptional();
            this.Property(t => t.LastUpdateTime).IsOptional();
        }
    }
}
