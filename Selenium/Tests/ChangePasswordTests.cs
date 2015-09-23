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
        private string oldPassword = "Password11";
        private string newPassword = "Password12";

        [SetUp]
        public void SetUp()
        {
            app = ((HomePO)new HomePO(Driver).LoginAs(username, oldPassword));
        }

        [Test]
        public void ShouldChangePasswordSuccessfully()
        {
            var changePasswordPage = app.ChangePassword(oldPassword, newPassword, newPassword);
            Assert.AreEqual(1, changePasswordPage.GetSuccessCount());
            Assert.AreEqual(0, changePasswordPage.GetErrorCount());
            Assert.IsTrue(changePasswordPage.IsSuccessMessagePresent(
                Constants.Messages.Account.ChangePassword.SuccessPasswordChanged));

            changePasswordPage.ChangePassword(newPassword, oldPassword, oldPassword);
            Assert.AreEqual(1, changePasswordPage.GetSuccessCount());
            Assert.AreEqual(0, changePasswordPage.GetErrorCount());
            Assert.IsTrue(changePasswordPage.IsSuccessMessagePresent(
                Constants.Messages.Account.ChangePassword.SuccessPasswordChanged));
        }

        [Test]
        public void InvalidOldPasswordShouldNOTChangePassword()
        {
            var changePasswordPage = app.ChangePassword("INVALID PASSWORD", newPassword, newPassword);

            Assert.AreEqual(0, changePasswordPage.GetSuccessCount());
            Assert.AreEqual(1, changePasswordPage.GetErrorCount());

            Assert.IsTrue(changePasswordPage.IsErrorPresent(
                Constants.Messages.Account.ChangePassword.InvalidOldPassword));
        }

        [Test]
        public void MismatchedNewPasswordsShouldNOTChangePassword()
        {
            var changePasswordPage = app.ChangePassword(oldPassword, newPassword, "MISMATCHED NEW PASSWORD");

            Assert.AreEqual(0, changePasswordPage.GetSuccessCount());
            Assert.AreEqual(1, changePasswordPage.GetErrorCount());

            Assert.IsTrue(changePasswordPage.IsErrorPresent(
                Constants.Messages.Account.ChangePassword.MismatchedPasswords));
        }

        [Test]
        public void ShouldOnlySeePasswordPageIfLoggedIn()
        {
            var url = Constants.Urls.Account.ChangePassword;
            app.GoTo(url);
            Assert.IsFalse(app.IsOn404Page());

            app.Logout().GoTo(url);
            Assert.IsFalse(app.IsOn404Page());
        }
    }
}
