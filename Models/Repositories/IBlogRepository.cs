using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories
{
    public interface IBlogRepository : IRepository
    {
        Blog AddBlog(Blog blog);

        Blog GetBlogByTitle(string p);

        List<Blog> GetBlogs();

        //TODO: CHANGE TO INT IN DB
        Blog GetBlogById(int id);

        void IncrementViewCounter(Blog blog);
    }
}
