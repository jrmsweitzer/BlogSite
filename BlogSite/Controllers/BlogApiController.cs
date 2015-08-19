using Models;
using Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogSite.Controllers
{
    public class BlogApiController : ApiController
    {
        private readonly BlogService _blogService;

        public BlogApiController()
        {
            _blogService = new BlogService();
        }

        public List<Blog> GetBlogs()
        {
            var blogs = _blogService.GetBlogs();
            return blogs;
        }
    }
}
