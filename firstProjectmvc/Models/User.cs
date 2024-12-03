using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace firstProjectmvc.Models
{
    public class User
    {
        public List<User> MyUsers { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
