using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamDay.DAL;
using TeamDay.Models.EfModels;

namespace TeamDay.CoreServices.UserServices
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> repository;
        public UserService(IRepository<User> repoistory)
        {
            this.repository = repoistory;
        }
        public User LoginValidate(string nick, string pwd)
        {
            var data = this.repository.Get().SingleOrDefault(t => t.Password == pwd && (t.LoginName == nick || t.Email == nick || t.Phone == nick || t.Code == nick));
            if (data != null)
            {
                data.LastLoginTime = DateTime.Now;
                this.repository.Update(data);
            }
            return data;
        }

        public User PasswordValidate(string code, string pwd)
        {
            return this.repository.Get().SingleOrDefault(t => t.Password == pwd && t.Code == code);
        }


        public Task<User> LoginValidateAsync(string nick, string pwd)
        {
            return new Task<User>(() =>
           {
               var data = this.repository.Get().SingleOrDefault(t => t.Password == pwd && (t.LoginName == nick || t.Email == nick || t.Phone == nick || t.Code == nick));
               if (data != null)
               {
                   data.LastLoginTime = DateTime.Now;
                   this.repository.Update(data);
               }
               return data;
           });
        }
    }
}
