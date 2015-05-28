using Models.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class BlogSeed : System.Data.Entity.DropCreateDatabaseIfModelChanges<BlogEntities>
    {
        protected override void Seed(BlogEntities context)
        {
            User user = new User
            {
                Username = "CCronan62@yahoo.com",
                JoinDate = DateTime.Now
            };

            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
