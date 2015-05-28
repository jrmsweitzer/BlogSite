namespace Models.Migrations
{
    using Models.Impl;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.DAL.BlogEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.DAL.BlogEntities context)
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
