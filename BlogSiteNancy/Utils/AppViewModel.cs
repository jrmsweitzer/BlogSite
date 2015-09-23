using Models;
using Nancy;
using Nancy.Security;
using Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSiteNancy.Utils
{
    public class AppViewModel
    {
        private static AppViewModel _instance;

        private BlogService _blogService;
        private CategoryService _categoryService;
        private UserService _userService;
        private EncryptionService _encryptionService;
        private PermissionService _permissionService;

        private AuthenticatedUser _loggedInUser;
        private List<Blog> _blogs;
        private List<Category> _categories;

        private AppViewModel()
        {
            _blogService = new BlogService();
            _categoryService = new CategoryService();
            _userService = new UserService();
            _encryptionService = new EncryptionService();
            _permissionService = new PermissionService();
        }

        public static AppViewModel GetAppViewModel()
        {
            if (_instance == null)
            {
                _instance = new AppViewModel();
            }
            return _instance;
        }

        public BlogService BlogService { get { return _blogService; } }
        public UserService UserService { get { return _userService; } }
        public CategoryService CategoryService { get { return _categoryService; } }
        public EncryptionService EncryptionService { get { return _encryptionService; } }
        public PermissionService PermissionService { get { return _permissionService; } }

        public List<Blog> Blogs
        {
            get
            {
                if (_blogs == null)
                {
                    _blogs = _instance._blogService.GetBlogs();
                }
                return _blogs;
            }
        }

        public Blog MostViewedBlog { get { return Blogs.OrderByDescending(b => b.NumViews).FirstOrDefault(); } }
        public Blog MostRecentBlog { get { return Blogs.OrderByDescending(b => b.CreateDate).FirstOrDefault(); } }
        public Blog MostSharedBlog { get { return Blogs.OrderByDescending(b => b.NumShares).FirstOrDefault(); } }
        public Blog MostLikedBlog { get { return Blogs.OrderByDescending(b => b.BlogLikes.Count).FirstOrDefault(); } }

        public Blog GetBlogByTitle(string title)
        {
            return Blogs.FirstOrDefault(b => b.Title.ToLower().Equals(title.ToLower()));
        }

        public AuthenticatedUser LoggedInUser {
            get { return _loggedInUser; } 
            set { _loggedInUser = value; } }

        public List<Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    _categories = _instance._categoryService.GetCategories();
                }
                return _categories;
            }
        }

        public void RefreshBlogs()
        {
            _blogs = _instance._blogService.GetBlogs();
        }
    }
}