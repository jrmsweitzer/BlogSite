using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories.Impl
{
    public class BlogRepository : BaseRepository, IBlogRepository
    {
        public BlogRepository()
        {
            _db = new BlogEntities();
        }

        public BlogRepository(IBlogEntities db)
        {
            _db = db;
        }

        public Blog AddBlog(Blog blog)
        {
            _db.Blogs.Add(blog);
            SaveChanges();
            return blog;
        }

        public Blog GetBlogByTitle(string title)
        {
            return _db.Blogs.FirstOrDefault(b => b.Title.Equals(title));
        }


        public List<Blog> GetBlogs()
        {
            return _db.Blogs.ToList();
        }


        public Blog GetBlogById(int id)
        {
            return _db.Blogs.FirstOrDefault(b => b.ID == id);
        }


        public void IncrementViewCounter(Blog b)
        {
            var blog = GetBlogById(b.ID);
            blog.NumViews++;
            SaveChanges();
        }

        public Blog GetMostViewedBlog()
        {
            return _db.Blogs.OrderByDescending(b => b.NumViews).FirstOrDefault();
        }

        public Blog GetNewestBlog()
        {
            return _db.Blogs.OrderByDescending(b => b.CreateDate).FirstOrDefault();
        }


        public List<Blog> GetBlogsByUsername(string username)
        {
            return _db.Blogs.Where(b => b.User.UserName.ToLower().Equals(username.ToLower())).ToList();
        }
    }
}
