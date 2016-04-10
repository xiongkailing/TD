using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamDay.Models.EfModels;

namespace TeamDay.Testor
{
    public class KeyValue:EfBaseModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
