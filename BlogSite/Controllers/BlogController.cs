using Models;
using Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Controllers
{
    public class BlogController : Controller
    {
        private BlogService _blogService;
        private UserService _userService;

        public BlogController()
        {
            _blogService = new BlogService();
            _userService = new UserService();
        }

        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Blog model)
        {
            User user = _userService.GetAnonymousUser();

            Blog blog = new Blog
            {
                ApprovalDate = DateTime.Now,
                CreateDate = DateTime.Now,
                IsApproved = true,
                NumShares = 0,
                NumViews = 0,
                Post = model.Post,
                Title = model.Title,
                User = user,
                UserID = user.ID
            };

            _blogService.AddBlog(blog);

            return RedirectToAction("Index", "Blog");
        }
    }
}