using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamDay.Models.RedisModels;

namespace TeamDay.CoreServices.VerifycodeServices
{
    public interface IImageVerifyService
    {
        void Add(VerifyCode code);
        VerifyCode GetByKey(string key);
    }
}
