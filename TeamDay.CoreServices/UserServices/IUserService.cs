using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamDay.Models.EfModels;

namespace TeamDay.CoreServices.UserServices
{
    public interface IUserService
    {
        User LoginValidate(string nick, string pwd);
        User PasswordValidate(string code, string pwd);
        Task<User> LoginValidateAsync(string nick, string pwd);
    }
}
