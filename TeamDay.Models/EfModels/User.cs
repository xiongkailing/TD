using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDay.Models.EfModels
{
    public class User : EfBaseModel
    {
        public string Name { get; set; }
        public virtual UserRole Role { get; set; }
        public string LoginName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime LastLoginTime { get; set; }
        public bool IsMailValidated { get; set; }
        public bool IsPhoneValidated { get; set; }
        public string Pictures { get; set; }
        public string Code { get; set; }
        public bool Gender { get; set; }
        public string Intro { get; set; }
    }
}
