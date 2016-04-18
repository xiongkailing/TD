using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDay.Components
{
    public class NoConfigFoundException : Exception
    {
        public string ConfigName { get; set; }
        public string AppDomain { get; set; }
        public NoConfigFoundException(string configName,string appDomain)
            : base()
        {
            this.ConfigName = configName;
            this.AppDomain = appDomain;
        }
    }
}
