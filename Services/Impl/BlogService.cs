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

        public BlogService()
        {
            _blogRepo = new BlogRepository();
        }

        public Blog AddBlog(Blog blog)
        {
            return _blogRepo.AddBlog(blog);
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
