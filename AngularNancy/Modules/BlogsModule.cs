using AngularNancy.Base.DTO;
using Nancy;
using Services.Impl;
using System.Linq;

namespace AngularNancy.Modules
{
    public class BlogsModule : NancyModule
    {
        private BlogService blogService;

        public BlogsModule()
        {
            blogService = new BlogService();

            Get["/api/v1/blogs"] = _ =>
            {
                var results = blogService.GetBlogs();
                return results.Select(p => AutoMapper.Mapper.DynamicMap<BlogDTO>(p));
            };

            Get["/api/v1/blog/{blogTitle}"] = _ =>
            {
                var result = blogService.GetBlogByTitle(_.blogTitle);
                return AutoMapper.Mapper.DynamicMap<BlogDTO>(result);
            };
        }
    }
}