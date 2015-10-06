using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Repositories;

namespace Models
{
    public partial class Blog
    {
        public Blog(string title, string content, List<string> tags, bool allowComments, User user)
        {
            this.AllowComments = allowComments;
            this.ApprovalDate = DateTime.Now;
            this.BlogLikes = new List<BlogLike>();
            this.CreateDate = DateTime.Now;
            this.Comments = new List<Comment>();
            this.IsApproved = true;
            this.NumShares = 0;
            this.NumViews = 0;
            this.Post = content;
            this.Title = title;
            this.User = user;
            this.Tags = string.Join(", ", tags);
        }

        public Blog(Blog blog)
        {
            this.AllowComments = blog.AllowComments;
            this.ApprovalDate = blog.ApprovalDate;
            this.BlogLikes = new List<BlogLike>();
                foreach (var like in blog.BlogLikes)
                {
                    this.BlogLikes.Add(like);
                }
            this.Comments = new List<Comment>();
                foreach (var comment in blog.Comments)
                {
                    this.Comments.Add(comment);
                }
            this.CreateDate = blog.CreateDate;
            this.ID = blog.ID;
            this.IsApproved = blog.IsApproved;
            this.NumShares = blog.NumShares;
            this.NumViews = blog.NumViews;
            this.Post = blog.Post;
            this.PostPreview = blog.PostPreview;
            this.Tags = blog.Tags;
            this.Title = blog.Title;
            this.User = blog.User;
        }

        public string PostedBy
        {
            get
            {
                return User.UserName;
            }
        }
    }
}
