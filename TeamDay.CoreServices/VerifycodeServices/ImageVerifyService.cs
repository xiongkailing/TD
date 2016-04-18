using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamDay.DAL;
using TeamDay.Models.RedisModels;

namespace TeamDay.CoreServices.VerifycodeServices
{
    public class ImageVerifyService:IImageVerifyService
    {
        private IRedisRepository<VerifyCode> repository;
        public ImageVerifyService(IRedisRepository<VerifyCode> repository)
        {
            this.repository = repository;
        }
        /// <summary>
        /// 添加图片验证码
        /// </summary>
        /// <param name="code">验证码</param>
        public void Add(VerifyCode code)
        {
            this.repository.Add(code, expireTime: DateTime.Now.AddMinutes(30));
        }
        /// <summary>
        /// 查询验证码
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>验证码</returns>
        public VerifyCode GetByKey(string key)
        {
            return this.repository.GetByKey(key);
        }
    }
}
