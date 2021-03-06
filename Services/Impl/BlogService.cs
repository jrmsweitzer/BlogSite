﻿using Models;
using Models.Repositories;
using Models.Repositories.Impl;
using System.Collections.Generic;

namespace Services.Impl
{
    public class BlogService
    {
        IBlogRepository _blogRepo;

        public BlogService()
        {
            _blogRepo = new BlogRepository();
        }

        public Blog AddBlog(Blog blog)
        {
            return _blogRepo.AddBlog(blog);
        }

        public List<Blog> GetBlogs()
        {
            return _blogRepo.GetBlogs();
        }

        public Blog GetBlogById(int id)
        {
            return _blogRepo.GetBlogById(id);
        }

        public void IncrementViewCounter(Blog blog)
        {
            _blogRepo.IncrementViewCounter(blog);
        }

        public Blog GetMostViewedBlog()
        {
            return _blogRepo.GetMostViewedBlog();
        }

        public Blog GetNewestBlog()
        {
            return _blogRepo.GetNewestBlog();
        }

        public Blog GetBlogByTitle(string title)
        {
            return _blogRepo.GetBlogByTitle(title);
        }

        public List<Blog> GetBlogsByUsername(string username)
        {
            return _blogRepo.GetBlogsByUsername(username);
        }
    }
}
