using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biografen.Models
{
    public class CreateUser
    {
        public int createuserId { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string password { get; set; }
        public int phoneNumber { get; set; }
        public int userinfo { get; set; }
        public Customer customers { get; set; }

    }
}
