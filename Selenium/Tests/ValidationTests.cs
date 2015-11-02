using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using Selenium.Framework;
using Selenium.PageObjects;
using Selenium.PageObjects.Account;
using Selenium.PageObjects.Base;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Utilities;

namespace Selenium.Tests
{
    public class ValidationTests : PageObjectTest
    {
        private string username = "globaladmin@test.com";
        private string password = "Password11";
        private string newPassword = "Password12";

        [Test]
        public void LoginValidationTests()
        {
            // Empty Username
            LoginPageObject app = ((LoginPageObject)new HomePageObject(Driver)
                .LoginAs("", password));
            Assert.IsTrue(app.IsErrorPresent(
                Constants.Messages.Account.Login.MissingUsername));

            // Empty Password
            app.LoginAs(username, "");
            Assert.IsTrue(app.IsErrorPresent(
                Constants.Messages.Account.Login.MissingPassword));

            // Empty Username and Password
            app.LoginAs("", "");
            Assert.IsTrue(app.IsErrorPresent(
                Constants.Messages.Account.Login.MissingUsername));
            Assert.IsTrue(app.IsErrorPresent(
                Constants.Messages.Account.Login.MissingPassword));

            // Invalid Username
            app.LoginAs("InvalidUsername", password);
            Assert.IsTrue(app.IsErrorPresent(
                Constants.Messages.Account.Login.MismatchedUsernamePassword));

            // Invalid Password
            app.LoginAs(username, "InvalidPassword");
            Assert.IsTrue(app.IsErrorPresent(
                Constants.Messages.Account.Login.MismatchedUsernamePassword));

            // Invalid Username and Password
            app.LoginAs("InvalidUsername", "InvalidPassword");
            Assert.IsTrue(app.IsErrorPresent(
                Constants.Messages.Account.Login.MismatchedUsernamePassword));
            
            // Log In
            app.LoginAs(username, password);
            Assert.IsTrue(app.IsLoggedIn());

            // Log Out
            app.Logout();
            Assert.IsFalse(app.IsLoggedIn());
        }

        [Test]
        public void ChangePasswordValidationTests()
        {
            // Attempt to change password
            // Invalid Old Password
            ChangePasswordPageObject changePasswordPage = ((HomePageObject)new HomePageObject(Driver)
                .LoginAs(username, password)).ChangePassword(
                "INVALID PASSWORD", 
                newPassword, 
                newPassword);
            Assert.IsTrue(changePasswordPage.IsErrorPresent(
                Constants.Messages.Account.Manage.InvalidOldPassword));

            // Mismatched New Passwords
            changePasswordPage.ChangePassword(
                password, 
                newPassword, 
                "MISMATCHED NEW PASSWORD");
            Assert.IsTrue(changePasswordPage.IsErrorPresent(
                Constants.Messages.Account.Manage.MismatchedPasswords));

            // Change Password from oldPassword to newPassword
            changePasswordPage.ChangePassword(
                password, 
                newPassword, 
                newPassword);
            Assert.IsTrue(changePasswordPage.IsSuccessMessagePresent(
                Constants.Messages.Account.Manage.SuccessPasswordChanged));

            // Change Password from newPassword to oldPassword
            changePasswordPage.ChangePassword(
                newPassword, 
                password,
                password);
            Assert.IsTrue(changePasswordPage.IsSuccessMessagePresent(
                Constants.Messages.Account.Manage.SuccessPasswordChanged));
        }

        [Test]
        public void RegistrationValidationTests()
        {
            RegisterPageObject app = ((RegisterPageObject)new HomePageObject(Driver)
                .Register("", "", ""));
        }
    }
}
