using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDay.Models.EfModels
{
    public enum UserRole
    {
        /// <summary>
        /// 普通用户
        /// </summary>
        Ordinary = 1,
        /// <summary>
        /// 企业用户
        /// </summary>
        Enterprise = 2,
        /// <summary>
        /// Vip用户
        /// </summary>
        Vip = 4,
        /// <summary>
        /// 管理员
        /// </summary>
        Admin = 8
    }
}
