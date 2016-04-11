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
        Task<User> LoginValidate(string nick, string pwd);
        User PasswordValidate(string name, string pwd);
    }
}
