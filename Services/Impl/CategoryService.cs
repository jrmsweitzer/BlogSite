using Models;
using Models.Repositories.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class CategoryService
    {
        private CategoryRepository _repo;

        public CategoryService(CategoryRepository repo)
        {
            _repo = repo;
        }

        public CategoryService()
        {
            _repo = new CategoryRepository();
        }

        public List<Category> GetCategories()
        {
            return _repo.GetCategories();
        }

        public IQueryable<Blog> GetBlogs(int categoryID)
        {
            return _repo.GetBlogs(categoryID);
        }

        public Category GetCategory(int categoryID)
        {
            return _repo.GetCategory(categoryID);
        }
    }
}
