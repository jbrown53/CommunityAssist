using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityAssist.Models
{
    public class LoginClass
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public LoginClass() { }
        public LoginClass(string email, string pass)
        {
            Email = email;
            Password = pass;
        }
    }
}