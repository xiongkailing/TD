using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamDay.WebSite.Models.AccountModels
{
    public class RegisterViewModel
    {
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string VerifyCode { get; set; }
    }
}