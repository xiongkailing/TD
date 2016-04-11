using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamDay.WebSite.Models.AccountModels
{
    public class LoginViewModel
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 是否记住
        /// </summary>
        public bool IsRemember { get; set; }
        /// <summary>
        /// 验证码id
        /// </summary>
        public string VerifyCodeId { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string VerifyCode { get; set; }
    }
}