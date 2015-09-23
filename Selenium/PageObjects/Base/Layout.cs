using OpenQA.Selenium;
using Selenium.Framework;
using Utilities;

namespace Selenium.PageObjects.Base
{
    public class Layout : PageObject, IBlogPage
    {
        public Layout(IWebDriver driver) : base(driver)
        { 
            // DO NOTHING
        }

        // Locators
        private static readonly By LoginBtn = By.Id("LoginLink");
        private static readonly By RegisterBtn = By.Id("RegisterLink");
        private static readonly By ChangePasswordBtn = By.Id("ChangePasswordLink");
        private static readonly By LogoutBtn = By.Id("LogoutLink");

        // Logic
        /// <summary>
        /// Log in to the app
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public IBlogPage LoginAs(string username, string password)
        {
            if (ElementExists(LoginBtn))
            {
                Click(LoginBtn);
                WaitForUrl(Constants.Urls.Account.Login);
                return new LoginPO(_driver).LoginAs(username, password);
            }
            return null;
        }

        /// <summary>
        /// Logout from the app
        /// </summary>
        /// <returns></returns>
        public HomePO Logout()
        {
            if (ElementExists(LogoutBtn))
            {
                Click(LogoutBtn);
                return new HomePO(_driver);
            }
            return null;
        }

        /// <summary>
        /// Changes Password from anywhere in the app.
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <param name="confirmNewPassword"></param>
        /// <returns></returns>
        public ChangePasswordPO ChangePassword(string oldPassword, string newPassword, string confirmNewPassword)
        {
            if (ElementExists(ChangePasswordBtn))
            {
                Click(ChangePasswordBtn);
                WaitForUrl(Constants.Urls.Account.ChangePassword);
                return new ChangePasswordPO(_driver).ChangePassword(oldPassword, newPassword, confirmNewPassword);
            }
            return null;
        }

        /// <summary>
        /// Returns whether a user is logged in or not.
        /// </summary>
        /// <returns></returns>
        public bool IsLoggedIn()
        {
            return !ElementExists(LoginBtn);
        }

        /// <summary>
        /// Returns whether we're on a 404 page or not.
        /// </summary>
        /// <returns></returns>
        public bool IsOn404Page()
        {
            return GetTitle().Contains("404");
        }
    }
}
