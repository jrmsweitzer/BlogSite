using Models;
using Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ViewModels;
using WebApplication1.ViewModels.Blog;

namespace WebApplication1.Controllers
{
    public class BlogController : Controller
    {
        BlogService _blogService = new BlogService();
        UserService _userService = new UserService();

        // GET: Blog
        [HttpGet]
        public ActionResult All()
        {
            var Blogs = _blogService.GetBlogs();
            return View(Blogs);
        }

        [HttpGet]
        public ActionResult Index(string title)
        {
            if (title == null || title.Equals(""))
            {
                return View("All");
            }
            var blog = _blogService.GetBlogByTitle(title);
            return View(blog);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(BlogCreateVM model)
        {
            if (model.IsValid)
            {
                SessionModels.CurrentBlog = model;
                return View("preview", model);
            }
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Submit()
        {
            User user;
            user = _userService.GetAnonymousUser();

            BlogCreateVM model = SessionModels.CurrentBlog;

            var blog = new Blog
            {
                ApprovalDate = DateTime.Now,
                CreateDate = DateTime.Now,
                IsApproved = true,
                NumShares = 0,
                NumViews = 0,
                Post = model.Text,
                Title = model.Title,
                UserID = user.ID,
                User = user
            };

            _blogService.AddBlog(blog);

            return View("Index", blog);
        }


    }
}