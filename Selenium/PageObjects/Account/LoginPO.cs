using OpenQA.Selenium;
using Selenium.PageObjects.Base;

namespace Selenium.PageObjects
{
    public class LoginPO : ValidatablePageObject
    {
        public LoginPO(IWebDriver driver) : base(driver) 
        { 
            // DO NOTHING 
        }

        // Locators
        private static readonly By UsernameTextbox = By.Id("LoginUsername");
        private static readonly By PasswordTextbox = By.Id("LoginPassword");
        private static readonly By LoginButton = By.Id("LoginButton");

        /// <summary>
        /// Logs into the app with the supplied credentials
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public IBlogPage LoginAs(string username, string password)
        {
            ClearAndSendKeys(UsernameTextbox, username);
            ClearAndSendKeys(PasswordTextbox, password);
            Click(LoginButton);
            if (GetErrorCount() == 0)
            {
                return new HomePO(_driver);
            }
            return this;
        }
    }
}
