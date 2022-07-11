using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_1.Models
{
    public class Users
    {
        public int id { get; set; }
        public string name { get; set; }
        public string usrName { get; set; }
        public string email { get; set; }
        public string cnum { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }
}