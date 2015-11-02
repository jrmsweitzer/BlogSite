using Nancy;
using Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSiteAngular.Modules
{
    public class BlogModule : NancyModule
    {
        private BlogService blogService;

        public BlogModule()
        {
            blogService = new BlogService();

            Get["/blogs/all"] = _ =>
            {
                return Response.AsJson(blogService.GetBlogs());
            };
        }
    }
}