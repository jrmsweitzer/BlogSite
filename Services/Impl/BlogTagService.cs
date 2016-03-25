using Models;
using Models.Repositories;
using Models.Repositories.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class BlogTagService
    {
        IBlogTagRepository _blogTagRepo;
        TagService _tagService;

        public BlogTagService()
        {
            _blogTagRepo = new BlogTagRepository();
            _tagService = new TagService();
        }

        public IQueryable<Tag> GetTags(int blogID)
        {
            return _blogTagRepo.GetTags(blogID);
        }

        public IQueryable<Blog> GetBlogs(int tagID)
        {
            return _blogTagRepo.GetBlogs(tagID);
        }

        public List<BlogTag> AddBlogTags(int blogId, string commaSeparatedTags)
        {
            List<string> list = commaSeparatedTags.Split(',').ToList();
            List<BlogTag> returns = new List<BlogTag>();

            foreach (string tagName in list)
            {
                var name = tagName.Trim();
                var tag = _tagService.GetTag(name);
                if (tag == null)
                {
                    _tagService.AddTag(name);
                    tag = _tagService.GetTag(name);
                }
                var blogtag = _blogTagRepo.AddBlogTag(blogId, tag.ID);
                returns.Add(blogtag);
            }

            return returns;
        }

    }
}
