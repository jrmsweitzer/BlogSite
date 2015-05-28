using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Impl
{
    public class Blog
    {
        // Primary Key
        public int ID { get; set; }
        // Foreign Keys
        public int UserID { get; set; }
        // Data
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public int NumViews { get; set; }
        public int NumShares { get; set; }
        public bool IsApproved { get; set; }
        // Navigation Properties
        public User User;
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

    }
}
