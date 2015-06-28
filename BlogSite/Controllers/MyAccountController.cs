using BlogSite.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Controllers
{
    public class MyAccountController : BaseController
    {
        // GET: MyAccount
        public ActionResult Index()
        {
            if (SessionUser == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(SessionUser);
        }
    }
}