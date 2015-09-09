using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public partial class User
    {
        public Blog MostViewedBlog
        {
            get
            {
                return Blogs.OrderByDescending(b => b.NumViews).FirstOrDefault();
            }
        }

        public Blog MostRecentBlog
        {
            get
            {
                return Blogs.OrderByDescending(b => b.CreateDate).FirstOrDefault();
            }
        }

        public bool IsAnonymous()
        {
            return this.UserName.ToLower().Equals("anonymous");
        }
    }
}
