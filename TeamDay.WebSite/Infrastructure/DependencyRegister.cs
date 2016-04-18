using Autofac;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TeamDay.CoreServices.UserServices;
using TeamDay.CoreServices.VerifycodeServices;
using TeamDay.DAL;
using TeamDay.Models.EfModels;
using TeamDay.Models.RedisModels;

namespace TeamDay.WebSite.Infrastructure
{
    public class DependencyRegister
    {
        public static void Register(ContainerBuilder builder)
        {
            builder.Register(t => new TeamDayDbContext()).As<DbContext>().InstancePerRequest();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerRequest();
            builder.Register(t => new PooledRedisClientManager(WebConfig.RedisConnectString)).As<IRedisClientsManager>().InstancePerRequest();
            builder.Register(t => new RedisRepository<VerifyCode>(t.Resolve<IRedisClientsManager>(), 1)).As<IRedisRepository<VerifyCode>>();
            builder.Register(t => new UserService(t.Resolve<IRepository<User>>())).As<IUserService>().InstancePerRequest();
            builder.Register(t => new ImageVerifyService(t.Resolve<IRedisRepository<VerifyCode>>())).As<IImageVerifyService>().InstancePerRequest();
        }
    }
}