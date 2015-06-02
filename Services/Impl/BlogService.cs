using Models;
using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class BlogService
    {
        BlogRepository _blogRepo;

        public BlogService()
        {
            _blogRepo = new BlogRepository();
        }

        public Blog AddBlog(Blog blog)
        {
            return _blogRepo.AddBlog(blog);
        }
    }
}
