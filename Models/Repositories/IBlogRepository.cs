using System;
using System.Collections.Generic;

namespace Models.Repositories
{
    public interface IBlogRepository : IDisposable
    {
        List<Blog> GetBlogs();
        Blog GetBlogById(int id);
        Blog GetBlogByTitle(string title);
        Blog GetMostViewedBlog();
        Blog GetNewestBlog();
        List<Blog> GetBlogsByUsername(string username);
        Blog AddBlog(Blog blog);
        void IncrementViewCounter(Blog blog);
        int SaveChanges();
    }
}
