using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDemo.Models
{
    public class LoginInfo
    {
        public string Email { set; get; }
        public string Password { set; get; }
    }
    public class RegisterInfo
    {
        public string Email { set; get; }
        public string Fullname { set; get; }
        public bool Sex { set; get; }
        public DateTime Birthday { set; get; }
        public string Password { set; get; }
    }
}
