using Models;
using Models.KO.Blog;
using Services.Impl;
using System;
using System.Net;
using System.Web.Mvc;

namespace BlogSite.Controllers
{
    public class BlogController : BaseController
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
            return View(new List());
        }

        // GET: Blog/Details/5
        public ActionResult Details(int id)
        {
            Blog blog = _blogService.GetBlogById(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        public ActionResult Create()
        {
            return View(new BlogModel());
        }

        [HttpPost]
        public ActionResult Create(BlogModel model)
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