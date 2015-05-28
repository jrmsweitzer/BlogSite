using Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Controllers
{
    public class BlogController : Controller
    {
        private BlogEntities db;

        public BlogController()
        {
            db = new BlogEntities();
        }

        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }
    }
}