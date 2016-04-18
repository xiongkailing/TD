using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDay.Models.EfModels
{
    public abstract class EfBaseModel
    {
        public int Id { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual Nullable<DateTime> LastUpdateTime { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Nullable<DateTime> DeleteTime { get; set; }
    }
}
