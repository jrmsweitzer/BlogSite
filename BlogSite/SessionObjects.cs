using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace BlogSite
{
    public class SessionObjects
    {
        public User User 
        {
            get { return (User)(HttpContext.Current.Session["User"]); }
            set { HttpContext.Current.Session["User"] = value; }
        }
    }
}