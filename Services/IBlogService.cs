using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBlogService
    {
        Blog AddBlog(Blog blog);
        List<Blog> GetBlogs();
        Blog GetBlogById(int id);
        void IncrememntViewCounter(Blog blog);
        Blog GetMostViewedBlog();
        Blog GetNewestBlog();
        Blog GetBlogByTitle(string title);
        List<Blog> GetBlogsByUsername(string username);
    }
}
