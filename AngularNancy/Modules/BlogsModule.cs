using AngularNancy.ViewModels;
using Models;
using Nancy;
using Nancy.ModelBinding;
using Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AngularNancy.Modules
{
    public class BlogsModule : NancyModule
    {
        private BlogService blogService;
        private BlogTagService blogTagService;
        private CategoryService categoryService;

        public BlogsModule()
        {
            blogService = new BlogService();
            blogTagService = new BlogTagService();
            categoryService = new CategoryService();

            Get["/api/v1/blogs"] = _ =>
            {
                List<Blog> listBlog = blogService.GetBlogs();

                var results =
                    listBlog.Select(p => AutoMapper.Mapper.DynamicMap<BlogDTO>(p));

                List<BlogDTO> returns = new List<BlogDTO>();

                foreach (var blog in results)
                {
                    List<Tag> blogTags = blogTagService.GetTags(blog.ID).ToList();

                    var tags =
                        blogTags.Select(t => AutoMapper.Mapper.DynamicMap<TagDTO>(t));
                    blog.Tags = new List<TagDTO>();
                    foreach(var tag in tags)
                    {
                        blog.Tags.Add(tag);
                    }

                    blog.CategoryDTO =
                        AutoMapper.Mapper.DynamicMap<CategoryDTO>(
                            categoryService.GetCategoryById(blog.CategoryID));

                    returns.Add(blog);
                }
                return returns;
            };

            Get["/api/v1/blog/{blogTitle}"] = _ =>
            {
                Blog blog = blogService.GetBlogByTitle(_.blogTitle);
                BlogDTO blogDTO = AutoMapper.Mapper.DynamicMap<BlogDTO>(blog);
                blogDTO.Tags = new List<TagDTO>();
                var tags = 
                    blogTagService
                        .GetTags(blog.ID).ToList()
                        .Select(t => AutoMapper.Mapper.DynamicMap<TagDTO>(t));

                foreach (var tag in tags)
                {
                    blogDTO.Tags.Add(tag);
                }

                return blogDTO;
            };

            Get["/api/v1/blogs/{userName}"] = _ =>
            {
                List<Blog> results = blogService.GetBlogsByUsername(_.userName);
                return results.Select(p => AutoMapper.Mapper.DynamicMap<BlogDTO>(p))
                    .OrderByDescending(p => p.CreateDate);
            };

            Post["/api/v1/blog/new"] = _ =>
            {
                var blog = this.Bind<Blog>();

                var now = DateTime.Now;
                blog.CreateDate = now;
                blog.ApprovalDate = now;

                blog.IsApproved = true;
                blog.NumShares = 0;
                blog.NumViews = 0;
                blog.CategoryID = 1;

                blog.UserID = 1;

                blogService.AddBlog(blog);

                return new Response
                {
                    StatusCode = HttpStatusCode.OK
                };
            };
        }
    }
}