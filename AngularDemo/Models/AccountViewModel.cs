using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDemo.Models
{
    public class LoginInfo
    {
        [Required]
        public string Email { set; get; }
        [Required]
        public string Password { set; get; }
    }
    public class RegisterInfo
    {
        [Required]
        public string Email { set; get; }
        [Required]
        [StringLength(30)]
        public string FirstName { set; get; }
        [Required]
        [StringLength(40)]
        public string LastNames { set; get; }
        public bool Sex { set; get; }
        public DateTime Birthday { set; get; }
        [Required]
        public string Password { set; get; }
    }
}
