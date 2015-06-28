using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using System.Web.SessionState;

namespace BlogSite
{
    public static class SessionObjects
    {
        private static HttpSessionState Session { get { return HttpContext.Current.Session; } }

        public static User User 
        {
            get { return ((Session["User"] is User) ? (User)Session["User"] : null); }
            set { Session["User"] = value; }
        }
    }
}