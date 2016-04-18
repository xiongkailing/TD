using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamDay.Models.EfModels
{
    public class User : EfBaseModel
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public virtual UserRole Role { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [Index(IsClustered=false)]
        public string Email { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [Index(IsClustered=false)]
        public string Phone { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 上次登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }
        /// <summary>
        /// 邮箱是否验证
        /// </summary>
        public bool IsMailValidated { get; set; }
        /// <summary>
        /// 电话是否验证
        /// </summary>
        public bool IsPhoneValidated { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string Picture { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        [Index(IsClustered=false)]
        public string Code { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public bool Gender { get; set; }
        /// <summary>
        /// 介绍
        /// </summary>
        public string Intro { get; set; }
        /// <summary>
        /// 积分
        /// </summary>
        public virtual RewardPoint Point { get; set; }
    }
}
