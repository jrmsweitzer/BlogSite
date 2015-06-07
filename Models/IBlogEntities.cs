using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IBlogEntities
    {
        DbSet<Blog> Blogs { get; set; }
        DbSet<BlogLike> BlogLikes { get; set; }
        DbSet<BlogTag> BlogTags { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<CommentLike> CommentLikes { get; set; }
        DbSet<Permission> Permissions { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<User> Users { get; set; }

        int SaveChanges();
    }
}
