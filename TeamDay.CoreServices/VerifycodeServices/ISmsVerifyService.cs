using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamDay.Components;
using TeamDay.Models.RedisModels;

namespace TeamDay.CoreServices.VerifycodeServices
{
    /// <summary>
    /// 短信验证码
    /// </summary>
    public interface ISmsVerifyService
    {
        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="phone">电话号码</param>
        void SendSms(string phone);
        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="code">验证码</param>
        /// <returns>验证码</returns>
        VerifyCode Validate(string phone, string code);
    }
}
