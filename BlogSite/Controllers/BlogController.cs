﻿using BlogSite.Controllers.Base;
using Models;
using Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
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
            return View(_blogService.GetBlogs());
        }

        // GET: Blog/5
        public ActionResult Blogs(int id)
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
            _blogService.IncrementViewCounter(blog);
            return View("Details", blog);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([FromJson] Blog model)
        {
            User user;
            if (SessionUser == null)
            {
                user = _userService.GetAnonymousUser();
            }
            else
            {
                user = _userService.GetUserByUserName(SessionUser.UserName);
            }

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