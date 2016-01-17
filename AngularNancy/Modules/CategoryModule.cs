using AngularNancy.ViewModels;
using Models;
using Nancy;
using Services.Impl;
using System.Collections.Generic;
using System.Linq;

namespace AngularNancy.Modules
{
    public class CategoryModule : NancyModule
    {
        private CategoryService categoryService;

        public CategoryModule()
        {
            categoryService = new CategoryService();

            Get["api/v1/categories"] = _ =>
            {
                List<Category> listCategory = categoryService.GetCategories();

                var results =
                    listCategory.Select(c => AutoMapper.Mapper.DynamicMap<CategoryDTO>(c))
                        .OrderBy(c => c.Name);

                List<CategoryDTO> returns = new List<CategoryDTO>();

                foreach(var category in results)
                {
                    List<Blog> blogCategories = categoryService.GetBlogs(category.ID).ToList();

                    var blogs =
                        blogCategories.Select(b => AutoMapper.Mapper.DynamicMap<BlogDTO>(b));
                    category.Blogs = new List<BlogDTO>();
                    foreach(var blog in blogs)
                    {
                        category.Blogs.Add(blog);
                    }

                    returns.Add(category);
                }

                return returns;
            };

            Get["api/v1/categories/{categoryID}"] = _ =>
            {
                CategoryDTO category = AutoMapper.Mapper.DynamicMap<CategoryDTO>(
                    categoryService.GetCategory(_.categoryID));
                category.Blogs = new List<BlogDTO>();
                var blogs =
                    categoryService.GetBlogs(category.ID).ToList()
                    .Select(b => AutoMapper.Mapper.DynamicMap<BlogDTO>(b));

                foreach(var blog in blogs)
                {
                    category.Blogs.Add(blog);
                }

                return category;
            };
        }
    }
}