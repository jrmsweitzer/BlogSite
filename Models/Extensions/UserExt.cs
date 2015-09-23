using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public partial class User
    {
        public User(string username, string hashedPassword, int permissionId)
        {
            this.GUID = System.Guid.NewGuid().ToString();
            this.HashedPassword = hashedPassword;
            this.IsActive = true;
            this.JoinDate = DateTime.Now;
            this.UserName = username;
            this.PermissionID = permissionId;
        }

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
