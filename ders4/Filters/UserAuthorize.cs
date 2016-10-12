using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ders4.Filters
{
    public class UserAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (Convert.ToBoolean(httpContext.Session["admin"]) == true)
            {
                return true;
            }
            else
            {
                httpContext.Response.Redirect("/Home/Index");
                return false;
            }

        }

    }
}