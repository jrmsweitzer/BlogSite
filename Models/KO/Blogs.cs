using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Repositories;
using Models.Repositories.Impl;

namespace Models.KO
{
    public class Blogs
    {
        private readonly IBlogRepository _blogRepository;

        public Blogs()
        {
            _blogRepository = new BlogRepository();
        }
        public List<Blog> ListBlogs { get { return _blogRepository.GetBlogs(); } } 
    }
}
