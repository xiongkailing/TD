using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TeamDay.Helpers;
using TeamDay.Models.EfModels;

namespace TeamDay.WebSite.Infrastructure
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<TeamDayDbContext>
    {
        public override void InitializeDatabase(TeamDay.WebSite.Infrastructure.TeamDayDbContext context)
        {
            base.InitializeDatabase(context);
        }

        protected override void Seed(TeamDayDbContext context)
        {
            try
            {
                context.Set<User>().Add(new User
                {
                    Name = "熊开玲",
                    Code = CommonHelper.GenerateUniqueStr(),
                    CreateTime = DateTime.Now,
                    Email = "kailingbear@126.com",
                    Gender = true,
                    Intro = "author&admin",
                    IsDeleted = false,
                    IsMailValidated = true,
                    IsPhoneValidated = true,
                    Phone = "18521030064",
                    Password = "e10adc3949ba59abbe56e057f20f883e",
                    Role = UserRole.Admin,
                    Picture = "",
                    LastLoginTime = DateTime.Now,
                    LoginName="xiongkailing"
                });
                context.SaveChanges();
                context.Set<RewardPoint>().Add(new RewardPoint
                {
                    CreateTime = DateTime.Now,
                    Point = 0,
                    User = context.Set<User>().FirstOrDefault()
                });
                context.SaveChanges();
                base.Seed(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}