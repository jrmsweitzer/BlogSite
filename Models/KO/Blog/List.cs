using System.Collections.Generic;
using System.Linq;
using Models.Repositories;
using Models.Repositories.Impl;

namespace Models.KO.Blog
{
    public class List
    {
        private readonly IBlogRepository _blogRepository;
        private List<Models.Blog> _blogs;

        public List()
        {
            _blogRepository = new BlogRepository();
            _blogs = _blogRepository.GetBlogs();
        }

        public List<Models.Blog> GetBlogs()
        {
            return _blogs;
        }
        public List<Models.Blog> Blogs { get { return GetBlogs().ToList(); } } 
    }
}
