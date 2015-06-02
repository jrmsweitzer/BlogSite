using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories
{
    public class BlogRepository
    {
        private BlogEntities _db;

        public BlogRepository()
        {
            _db = new BlogEntities();
        }

        public Blog AddBlog(Blog blog)
        {
            if (GetBlogByTitle(blog.Title) == null)
            {
                _db.Blogs.Add(blog);
                SaveChanges();
                return blog;
            }
            return null;
        }

        public Blog GetBlogByTitle(string title)
        {
            return _db.Blogs.FirstOrDefault(b => b.Title.Equals(title));
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }
    }
}
