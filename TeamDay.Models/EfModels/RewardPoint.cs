using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDay.Models.EfModels
{
    public class RewardPoint : EfBaseModel
    {
        public virtual User User { get; set; }
        public int Point { get; set; }
    }
}
