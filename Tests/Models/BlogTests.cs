using Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests.Models
{
    [TestFixture]
    public class BlogTests
    {
        [Test]
        public void BlogConstructorTest()
        {
            Blog blog = new Blog();
            Assert.NotNull(blog);
            Assert.AreEqual(typeof(Blog), blog.GetType());
        }

        [Test]
        public void BlogConstructorWithCriteriaTest()
        {
            var title = "Test Title";
            var content = "This is content";
            var tags = "test tag 1, test tag 2, tag 3, i like balloons";
            var allowComments = true;

            var user = new User
            {
                UserName = "Test User",
                ID = -1
            };

            Blog blog = new Blog(title, content, allowComments, user);

            Assert.NotNull(blog);
            Assert.AreEqual(typeof(Blog), blog.GetType());

            Assert.AreEqual(title, blog.Title);
            Assert.AreEqual(content, blog.Post);
            Assert.AreEqual(allowComments, blog.AllowComments);
            Assert.AreEqual(user.UserName, blog.User.UserName);
            Assert.AreEqual(user.ID, blog.User.ID);
            Assert.AreEqual(user.UserName, blog.PostedBy);
        }


    }
}
