using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Controllers.Base
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Property that handles user object. 
        /// </summary>
        public User SessionUser
        {
            get
            {

                return SessionObjects.User;
            }
            set
            {
                SessionObjects.User = value;
            }
        }
    }
}