using BlogSiteNancy.Utils;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSiteNancy.Views.Blog.ViewModels
{
    public class NewBlogModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Tags { get; set; }
        public bool AllowComments { get; set; }
        public Category Category { get; set; }
        public Category[] Categories { get; set; }

        public NewBlogModel()
        {
            Tags = new List<string>();
            Categories = AppViewModel.GetAppViewModel().Categories.ToArray();
        }

        public bool IsValid()
        {
            return
                !string.IsNullOrEmpty(Title) &&
                !string.IsNullOrEmpty(Content);
        }

        public Models.Blog ToModel(Models.User user)
        {
            var blog = new Models.Blog();

            blog.AllowComments = this.AllowComments;
            blog.ApprovalDate = DateTime.Now;
            blog.BlogLikes = new List<BlogLike>();
            blog.Category = this.Category;
            blog.Comments = new List<Models.Comment>();
            blog.CreateDate = DateTime.Now;
            blog.IsApproved = true;
            blog.NumShares = 0;
            blog.NumViews = 0;
            blog.Post = this.Content;
            blog.Tags = string.Join(", ", this.Tags);
            blog.Title = this.Title;
            blog.User = user;

            return blog;
        }
    }
}