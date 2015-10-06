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
        private string newPassword = "Password12";

        [Test]
        public void AccountValidationTests()
        {
            // Empty Username
            LoginPO app = ((LoginPO)new HomePO(Driver).LoginAs("", password));
            Assert.AreEqual(0, app.GetSuccessCount());
            Assert.AreEqual(1, app.GetErrorCount());
            Assert.IsTrue(app.IsErrorPresent(
                Constants.Messages.Account.Login.MissingUsername));

            // Empty Password
            app.LoginAs(username, "");
            Assert.AreEqual(0, app.GetSuccessCount());
            Assert.AreEqual(1, app.GetErrorCount());
            Assert.IsTrue(app.IsErrorPresent(
                Constants.Messages.Account.Login.MissingPassword));

            // Empty Username and Password
            app.LoginAs("", "");
            Assert.AreEqual(0, app.GetSuccessCount());
            Assert.AreEqual(2, app.GetErrorCount());
            Assert.IsTrue(app.IsErrorPresent(
                Constants.Messages.Account.Login.MissingUsername));
            Assert.IsTrue(app.IsErrorPresent(
                Constants.Messages.Account.Login.MissingPassword));

            // Invalid Username
            app.LoginAs("InvalidUsername", password);
            Assert.AreEqual(0, app.GetSuccessCount());
            Assert.AreEqual(1, app.GetErrorCount());
            Assert.IsTrue(app.IsErrorPresent(
                Constants.Messages.Account.Login.MismatchedUsernamePassword));

            // Invalid Password
            app.LoginAs(username, "InvalidPassword");
            Assert.AreEqual(0, app.GetSuccessCount());
            Assert.AreEqual(1, app.GetErrorCount());
            Assert.IsTrue(app.IsErrorPresent(
                Constants.Messages.Account.Login.MismatchedUsernamePassword));

            // Invalid Username and Password
            app.LoginAs("InvalidUsername", "InvalidPassword");
            Assert.AreEqual(0, app.GetSuccessCount());
            Assert.AreEqual(1, app.GetErrorCount());
            Assert.IsTrue(app.IsErrorPresent(
                Constants.Messages.Account.Login.MismatchedUsernamePassword));
            
            // Log In
            app.LoginAs(username, password);
            app.WaitForUrl(Constants.Urls.Home);
            Assert.IsTrue(app.IsLoggedIn());

            // Attempt to change password
            // Invalid Old Password
            var changePasswordPage = app.ChangePassword("INVALID PASSWORD", newPassword, newPassword);
            Assert.AreEqual(0, changePasswordPage.GetSuccessCount());
            Assert.AreEqual(1, changePasswordPage.GetErrorCount());
            Assert.IsTrue(changePasswordPage.IsErrorPresent(
                Constants.Messages.Account.Manage.InvalidOldPassword));

            // Mismatched New Passwords
            changePasswordPage.ChangePassword(password, newPassword, "MISMATCHED NEW PASSWORD");
            Assert.AreEqual(0, changePasswordPage.GetSuccessCount());
            Assert.AreEqual(1, changePasswordPage.GetErrorCount());
            Assert.IsTrue(changePasswordPage.IsErrorPresent(
                Constants.Messages.Account.Manage.MismatchedPasswords));

            // Change Password from oldPassword to newPassword
            changePasswordPage.ChangePassword(password, newPassword, newPassword);
            Assert.AreEqual(1, changePasswordPage.GetSuccessCount());
            Assert.AreEqual(0, changePasswordPage.GetErrorCount());
            Assert.IsTrue(changePasswordPage.IsSuccessMessagePresent(
                Constants.Messages.Account.Manage.SuccessPasswordChanged));

            // Change Password from newPassword to oldPassword
            changePasswordPage.ChangePassword(newPassword, password, password);
            Assert.AreEqual(1, changePasswordPage.GetSuccessCount());
            Assert.AreEqual(0, changePasswordPage.GetErrorCount());
            Assert.IsTrue(changePasswordPage.IsSuccessMessagePresent(
                Constants.Messages.Account.Manage.SuccessPasswordChanged));

            // Log Out
            app.Logout();
            Assert.IsFalse(app.IsLoggedIn());
        }
    }
}
