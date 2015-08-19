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

        public List<Blog> GetBlogs()
        {
            var list = _blogRepo.GetBlogs();
            var newList = new List<Blog>();

            foreach (var blog in list)
            {
                newList.Add(new Blog(blog));
            };

            return newList;
        }

        public Blog GetBlogById(int id)
        {
            return _blogRepo.GetBlogById(id);
        }

        public void IncrementViewCounter(Blog blog)
        {
            _blogRepo.IncrementViewCounter(blog);
        }

        public Blog GetMostViewedBlog()
        {
            return _blogRepo.GetMostViewedBlog();
        }

        public Blog GetNewestBlog()
        {
            return _blogRepo.GetNewestBlog();
        }

        public Blog GetBlogByTitle(string title)
        {
            return _blogRepo.GetBlogByTitle(title);
        }

        public List<Blog> GetBlogsByUsername(string username)
        {
            return _blogRepo.GetBlogsByUsername(username);
        }
    }
}
