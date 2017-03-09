using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ChatJoke.Module.Filter
{
    public class AuthorizUserAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAut = base.AuthorizeCore(httpContext);
            return isAut;
        }
    }
}