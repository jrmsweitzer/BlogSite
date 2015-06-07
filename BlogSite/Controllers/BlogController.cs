using Models;
using Models.KO;
using Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogService _blogService;
        private readonly UserService _userService;

        public BlogController()
        {
            _blogService = new BlogService();
            _userService = new UserService();
        }

        // GET: Blog
        public ActionResult Index()
        {
            return View(new Blogs());
        }

        // GET: Blog/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = _blogService.GetBlogById(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([FromJson] Blog model)
        {
            User user = _userService.GetAnonymousUser();

            var blog = new Blog
            {
                ApprovalDate = DateTime.Now,
                CreateDate = DateTime.Now,
                IsApproved = true,
                NumShares = 0,
                NumViews = 0,
                Post = model.Post,
                Title = model.Title,
                UserID = user.ID
            };

            _blogService.AddBlog(blog);

            return RedirectToAction("Index", "Blog");
        }
    }
}