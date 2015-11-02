using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Framework;
using Selenium.PageObjects.Account;
using Utilities;

namespace Selenium.PageObjects.Base
{
    public class LayoutPageObject : PageObject, IBlogPage
    {
        public LayoutPageObject(IWebDriver driver)
            : base(driver)
        {
            // DO NOTHING
        }

        // Locators
        private static readonly By LoginButton = By.Id("LoginLink");
        private static readonly By RegisterButton = By.Id("RegisterLink");
        private static readonly By ChangePasswordButton = By.Id("ManageAccountLink");
        private static readonly By LogoutButton = By.Id("LogoutLink");

        // Logic
        /// <summary>
        /// Log in to the app
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public IBlogPage LoginAs(string username, string password)
        {
            if (ElementExists(LoginButton))
            {
                Click(LoginButton);
                WaitForUrl(Constants.Urls.Account.Login);
                return new LoginPageObject(_driver).LoginAs(username, password);
            }
            Assert.Fail("Attempted to log in when already logged in!");
            return null;
        }

        /// <summary>
        /// Takes the user to the registration page
        /// </summary>
        /// <returns></returns>
        public IBlogPage Register(
            string username, string password, string confirmPassword)
        {
            if (ElementExists(RegisterButton))
            {
                Click(RegisterButton);
                WaitForUrl(Constants.Urls.Account.Register);
                return new RegisterPageObject(_driver)
                    .Register(username, password, confirmPassword);
            }
            Assert.Fail("Attempted to register when already logged in!");
            return null;
        }

        /// <summary>
        /// Logout from the app
        /// </summary>
        /// <returns></returns>
        public HomePageObject Logout()
        {
            if (ElementExists(LogoutButton))
            {
                Click(LogoutButton);
                return new HomePageObject(_driver);
            }
            Assert.Fail("Attempted to log out when not logged in!");
            return null;
        }

        /// <summary>
        /// Changes Password from anywhere in the app.
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <param name="confirmNewPassword"></param>
        /// <returns></returns>
        public ChangePasswordPageObject ChangePassword(string oldPassword, string newPassword, string confirmNewPassword)
        {
            if (ElementExists(ChangePasswordButton))
            {
                Click(ChangePasswordButton);
                WaitForUrl(Constants.Urls.Account.Manage);
                return new ChangePasswordPageObject(_driver).ChangePassword(oldPassword, newPassword, confirmNewPassword);
            }
            Assert.Fail("Attempted to change password when not logged in!");
            return null;
        }

        /// <summary>
        /// Returns whether a user is logged in or not.
        /// </summary>
        /// <returns></returns>
        public bool IsLoggedIn()
        {
            return !ElementExists(LoginButton);
        }

        /// <summary>
        /// Returns whether we're on a 404 page or not.
        /// </summary>
        /// <returns></returns>
        public bool IsOn404Page()
        {
            return GetTitle().Contains("404");
        }

        /// <summary>
        /// Sets a user cookie
        /// </summary>
        public void SetUserCookie()
        {
            SetCookie(
                Constants.Cookies.Name,
                Constants.Cookies.UserCookieData);
        }

        public void SetAdminCookie()
        {
            SetCookie(
                Constants.Cookies.Name,
                Constants.Cookies.AdminCookieData);
        }
    }
}
