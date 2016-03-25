using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories
{
    public interface IBlogTagRepository : IDisposable
    {
        IQueryable<Tag> GetTags(int blogID);
        IQueryable<Blog> GetBlogs(int tagID);
        BlogTag AddBlogTag(int blogId, int tagId);
    }
}
