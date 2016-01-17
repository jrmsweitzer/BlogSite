using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories.Impl
{
    public class CategoryRepository : BaseRepository
    {
        public CategoryRepository()
        {
            _db = new BlogEntities();
        }

        public List<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }

        public Category GetCategory(int categoryID)
        {
            return _db.Categories.FirstOrDefault(c => c.ID == categoryID);
        }

        public IQueryable<Blog> GetBlogs(int categoryID)
        {
            return _db.Blogs
                .Where(b => b.CategoryID == categoryID);
        }
    }
}
