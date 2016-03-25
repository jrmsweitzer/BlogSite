using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Repositories;

namespace Models
{
    [Serializable]
    public partial class Blog
    {
        public Blog(string title, string content, bool allowComments, User user)
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
            this.UserID = user.ID;
        }

        public string PostedBy
        {
            get
            {
                if (User != null)
                {
                    return User.UserName;
                }
                return "";
            }
        }

        public List<Tag> ConvertTagsToList(string commaSeparatedTags)
        {

            return null;
        }
    }
}
