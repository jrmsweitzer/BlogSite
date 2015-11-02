using NUnit.Framework;
using Selenium.Framework;
using Selenium.PageObjects;
using Utilities;

namespace Selenium.Tests
{
    public class AuthorizationTests : PageObjectTest
    {
        HomePageObject app;
        private string AdminUsername = "globaladmin@test.com";
        private string UserUsername = "user@test.com";
        private string password = "Password11";

        [Test]
        public void ShouldNotSeePasswordPageIfNotLoggedIn()
        {
            var url = Constants.Urls.Account.Manage;
            app = new HomePageObject(Driver);
            app.GoTo(url);
            Assert.IsTrue(app.IsOn404Page());
        }

        [Test]
        public void ShouldSeePasswordPageIfLoggedIn()
        {
            app = ((HomePageObject)new HomePageObject(Driver).LoginAs(AdminUsername, password));
            app.WaitForUrl(Constants.Urls.Home);

            var url = Constants.Urls.Account.Manage;
            app.GoTo(url);
            Assert.IsFalse(app.IsOn404Page());
        }

        [Test]
        public void ShouldNotSeeCreateBlogPageIfNotLoggedIn()
        {
            var url = Constants.Urls.Blog.Create;
            app = new HomePageObject(Driver);
            app.GoTo(url);
            Assert.IsTrue(app.IsOn404Page());
        }

        [Test]
        public void ShouldNotSeeCreateBlogPageIfNotBlogCreator()
        {
            app = ((HomePageObject)new HomePageObject(Driver).LoginAs(UserUsername, password));
            app.WaitForUrl(Constants.Urls.Home);

            var url = Constants.Urls.Blog.Create;
            app.GoTo(url);
            Assert.IsTrue(app.IsOn404Page());
        }

        [Test]
        public void ShouldSeeCreateBlogPageIfBlogCreator()
        {
            app = ((HomePageObject)new HomePageObject(Driver).LoginAs(AdminUsername, password));
            app.WaitForUrl(Constants.Urls.Home);

            var url = Constants.Urls.Blog.Create;
            app.GoTo(url);
            Assert.IsTrue(app.IsOn404Page());
        }

        [Test]
        public void ShouldNotSeeAdminPageIfNotLoggedIn()
        {
            var url = Constants.Urls.Admin;
            app = new HomePageObject(Driver);
            app.GoTo(url);
            Assert.IsTrue(app.IsOn404Page());
        }

        [Test]
        public void ShouldSeeAdminPageIfLoggedInAsAdmin()
        {
            app = ((HomePageObject)new HomePageObject(Driver).LoginAs(AdminUsername, password));
            app.WaitForUrl(Constants.Urls.Home);

            var url = Constants.Urls.Admin;
            app.GoTo(url);
            Assert.IsTrue(app.IsOn404Page());
        }

        [Test]
        public void ShouldNotSeeAdminPageIfNotAdmin()
        {
            app = ((HomePageObject)new HomePageObject(Driver).LoginAs(UserUsername, password));
            app.WaitForUrl(Constants.Urls.Home);

            var url = Constants.Urls.Admin;
            app.GoTo(url);
            Assert.IsTrue(app.IsOn404Page());
        }
    }
}
