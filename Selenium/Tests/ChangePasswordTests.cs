using NUnit.Framework;
using Selenium.Framework;
using Selenium.PageObjects;
using Utilities;

namespace Selenium.Tests
{
    public class ChangePasswordTests : PageObjectTest
    {
        HomePO app;
        private string username = "globaladmin@test.com";
        private string password = "Password11";

        [Test]
        public void ShouldOnlySeePasswordPageIfLoggedIn()
        {
            app = ((HomePO)new HomePO(Driver).LoginAs(username, password));
            app.WaitForUrl(Constants.Urls.Home);

            var url = Constants.Urls.Account.Manage;
            app.GoTo(url);
            Assert.IsFalse(app.IsOn404Page());

            app.Logout().GoTo(url);
            Assert.IsTrue(app.IsOn404Page());
        }
    }
}
