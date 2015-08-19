using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSiteNancy.Views.User.ViewModels
{
    /// <summary>
    /// ViewModel for User Details.
    /// </summary>
    public class DetailsModel
    {
        private Models.User _user;

        public DetailsModel(Models.User user)
        {
            _user = user;
        }

        public string Username { get { return _user.UserName; } }
        public string JoinDate { get { return _user.JoinDate.ToString(); } }
        public Models.Blog MostRecentBlog { get { return _user.MostRecentBlog; } }
        public Models.Blog MostViewedBlog { get { return _user.MostViewedBlog; } }
        public int NumBlogs { get { return _user.Blogs.Count; } }
    }
}