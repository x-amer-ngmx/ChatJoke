using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatJoke.Models
{
    public class AuthModel
    {
        public string login { get; set; }

        public string password { get; set; }
    }

    public class RegModel : AuthModel
    {
        public string confirmPass { get; set; }
    }

    public class RemModel
    {
        public string UserName { get; set; }
        public string Ticket { get; set; }
    }
}