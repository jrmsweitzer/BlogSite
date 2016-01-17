using AngularNancy.ViewModels;
using Models;
using Nancy;
using Services.Impl;
using System.Collections.Generic;
using System.Linq;

namespace AngularNancy.Modules
{
    public class TagsModule : NancyModule
    {
        private TagService tagService;
        private BlogTagService blogTagService;

        public TagsModule()
        {
            tagService = new TagService();
            blogTagService = new BlogTagService();

            Get["/api/v1/tags"] = _ =>
            {
                List<Tag> listTag = tagService.GetTags();

                var results =
                    listTag.Select(p => AutoMapper.Mapper.DynamicMap<TagDTO>(p))
                        .OrderBy(t => t.Name);

                List<TagDTO> returns = new List<TagDTO>();

                foreach (var tag in results)
                {
                    List<Blog> blogTags = blogTagService.GetBlogs(tag.ID).ToList();

                    var blogs =
                        blogTags.Select(b => AutoMapper.Mapper.DynamicMap<BlogDTO>(b));
                    tag.Blogs = new List<BlogDTO>();
                    foreach(var blog in blogs)
                    {
                        tag.Blogs.Add(blog);
                    }

                    returns.Add(tag);
                }

                return returns;
            };

            Get["/api/v1/tags/{tagName}"] = _ =>
            {
                Tag tag = tagService.GetTag(_.tagName);
                TagDTO tagDTO = AutoMapper.Mapper.DynamicMap<TagDTO>(tag);
                tagDTO.Blogs = new List<BlogDTO>();
                var blogs =
                    blogTagService
                        .GetBlogs(tag.ID).ToList()
                        .Select(b => AutoMapper.Mapper.DynamicMap<BlogDTO>(b));

                foreach (var blog in blogs)
                {
                    tagDTO.Blogs.Add(blog);
                }

                return tagDTO;
            };
        }
    }
}