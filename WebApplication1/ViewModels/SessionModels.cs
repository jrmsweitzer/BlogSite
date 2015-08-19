using Models;
using Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels
{
    public static class SessionModels
    {
        private static BlogService _service = new BlogService();

        private static List<Models.Blog> _allBlogs;
        public static List<Models.Blog> AllBlogs
        {
            get
            {
                if (_allBlogs == null)
                {
                    _allBlogs = _service.GetBlogs();
                }
                return _allBlogs;
            }
        }

        public static Blog.BlogCreateVM CurrentBlog { get; set; }
    }
}