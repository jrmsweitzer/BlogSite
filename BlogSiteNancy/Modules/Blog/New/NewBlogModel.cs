using BlogSiteNancy.Utils;
using Models;
using System;
using System.Collections.Generic;

namespace BlogSiteNancy.Views.Blog.ViewModels
{
    public class NewBlogModel : Validatable
    {
        public bool AllowComments { get; set; }
        public int CategoryId { get; set; }
        public bool NSFW { get; set; }
        public string Content { get; set; }
        public string PostPreview { get; set; }
        public List<string> Tags { get; set; }
        public string Title { get; set; }
        public Category[] Categories { get; set; }

        public NewBlogModel()
        {
            Tags = new List<string>();
            Categories = AppViewModel.GetAppViewModel().Categories.ToArray();
        }

        public NewBlogModel(Models.Blog blog)
        {
            AllowComments = blog.AllowComments;
            CategoryId = (int)blog.CategoryID;
            NSFW = blog.NSFW;
            Content = blog.Post;
            PostPreview = blog.PostPreview;
            Tags = new List<string>();
            //Tags = blog.Tags;
            Title = blog.Title;
            Categories = AppViewModel.GetAppViewModel().Categories.ToArray();
        }

        public Models.Blog ToModel(int userId)
        {
            var blog = new Models.Blog();

            blog.AllowComments = this.AllowComments;
            blog.ApprovalDate = DateTime.Now;
            blog.CategoryID = this.CategoryId;
            blog.CreateDate = DateTime.Now;
            blog.IsApproved = true;
            blog.NumShares = 0;
            blog.NumViews = 0;
            blog.NSFW = this.NSFW;
            blog.Post = this.Content;
            blog.Tags = string.Join(", ", this.Tags);
            blog.Title = this.Title;
            blog.UserID = userId;
            blog.PostPreview = this.PostPreview;

            return blog;
        }
    }
}