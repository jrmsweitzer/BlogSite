using NUnit.Framework;
using Selenium.Framework;
using Selenium.PageObjects;
using Utilities;

namespace Selenium.Tests
{
    public class LoginTests : PageObjectTest
    {
        private string username = "globaladmin@test.com";
        private string password = "Password11";

        [Test]
        public void ShouldLoginSuccessfully()
        {
            HomePO app = ((HomePO)new HomePO(Driver).LoginAs(username, password));
            app.WaitForUrl(Constants.Urls.Home);

            Assert.IsTrue(app.IsLoggedIn());
        }

        [Test]
        public void ShouldLogOutSuccessfully()
        {
            HomePO app = ((HomePO)new HomePO(Driver).LoginAs(username, password));
            app.WaitForUrl(Constants.Urls.Home);
            Assert.IsTrue(app.IsLoggedIn());

            app.Logout();
            Assert.IsFalse(app.IsLoggedIn());
        }

        [Test]
        public void EmptyUsernameShouldNOTLogin()
        {
            LoginPO login = ((LoginPO)new HomePO(Driver).LoginAs("", password));

            Assert.AreEqual(0, login.GetSuccessCount());
            Assert.AreEqual(1, login.GetErrorCount());

            Assert.IsTrue(login.IsErrorPresent(
                Constants.Messages.Account.Login.MissingUsername));
        }

        [Test]
        public void EmptyPasswordShouldNOTLogin()
        {
            LoginPO login = ((LoginPO)new HomePO(Driver).LoginAs(username, ""));

            Assert.AreEqual(0, login.GetSuccessCount());
            Assert.AreEqual(1, login.GetErrorCount());

            Assert.IsTrue(login.IsErrorPresent(
                Constants.Messages.Account.Login.MissingPassword));
        }

        [Test]
        public void EmptyUsernameAndPasswordShouldNOTLogin()
        {
            LoginPO login = ((LoginPO)new HomePO(Driver).LoginAs("", ""));

            Assert.AreEqual(0, login.GetSuccessCount());
            Assert.AreEqual(2, login.GetErrorCount());

            Assert.IsTrue(login.IsErrorPresent(
                Constants.Messages.Account.Login.MissingUsername));
            Assert.IsTrue(login.IsErrorPresent(
                Constants.Messages.Account.Login.MissingPassword));
        }

        [Test]
        public void InvalidUsernameShouldNOTLogin()
        {
            LoginPO login = ((LoginPO)new HomePO(Driver).LoginAs("InvalidUsername", password));

            Assert.AreEqual(0, login.GetSuccessCount());
            Assert.AreEqual(1, login.GetErrorCount());

            Assert.IsTrue(login.IsErrorPresent(
                Constants.Messages.Account.Login.MismatchedUsernamePassword));
        }

        [Test]
        public void InvalidPasswordShouldNOTLogin()
        {
            LoginPO login = ((LoginPO)new HomePO(Driver).LoginAs(username, "InvalidPassword"));

            Assert.AreEqual(0, login.GetSuccessCount());
            Assert.AreEqual(1, login.GetErrorCount());

            Assert.IsTrue(login.IsErrorPresent(
                Constants.Messages.Account.Login.MismatchedUsernamePassword));
        }
    }
}
