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

        public BlogTagService()
        {
            _blogTagRepo = new BlogTagRepository();
        }

        public IQueryable<Tag> GetTags(int blogID)
        {
            return _blogTagRepo.GetTags(blogID);
        }

        public IQueryable<Blog> GetBlogs(int tagID)
        {
            return _blogTagRepo.GetBlogs(tagID);
        }
    }
}
