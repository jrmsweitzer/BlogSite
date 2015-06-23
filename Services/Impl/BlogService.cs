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
    public class BlogService
    {
        IBlogRepository _blogRepo;

        public BlogService(IBlogEntities db)
        {
            _blogRepo = new BlogRepository(db);
        }

        public BlogService()
        {
            var db = new BlogEntities();
            _blogRepo = new BlogRepository(db);
        }

        public Blog AddBlog(Blog blog)
        {
            Blog returnedBlog = _blogRepo.GetBlogByTitle(blog.Title);
            if (returnedBlog == null)
            {
                returnedBlog = _blogRepo.AddBlog(blog);
            }
            return returnedBlog;
        }

        public IEnumerable<Blog> GetBlogs()
        {
            return _blogRepo.GetBlogs();
        }

        public Blog GetBlogById(decimal id)
        {
            return _blogRepo.GetBlogById(id);
        }

        public void IncrementViewCounter(Blog blog)
        {
            _blogRepo.IncrementViewCounter(blog);
        }


    }
}
