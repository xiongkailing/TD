using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamDay.Components;

namespace TeamDay.CoreServices.VerifycodeServices
{
    public class SmsVerifyService:ISmsVerifyService
    {
        public void SendSms(string phone)
        {
            throw new NotImplementedException();
        }

        public Models.RedisModels.VerifyCode Validate(string phone, string code)
        {
            throw new NotImplementedException();
        }
    }
}
