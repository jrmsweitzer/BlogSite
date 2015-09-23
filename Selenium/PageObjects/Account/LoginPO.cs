using OpenQA.Selenium;
using Selenium.Framework;
using Selenium.PageObjects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Selenium.PageObjects
{
    public class LoginPO : ValidatablePageObject
    {
        public LoginPO(IWebDriver driver) : base(driver) 
        { 
            // DO NOTHING 
        }

        // Locators
        private static readonly By UsernameTextbox = By.Id("LoginInput");
        private static readonly By PasswordTextbox = By.Id("PasswordInput");
        private static readonly By LoginButton = By.Id("LoginButton");

        /// <summary>
        /// Logs into the app with the supplied credentials
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public IBlogPage LoginAs(string username, string password)
        {
            SendKeys(UsernameTextbox, username);
            SendKeys(PasswordTextbox, password);
            Click(LoginButton);
            if (GetErrorCount() == 0)
            {
                return new HomePO(_driver);
            }
            return this;
        }
    }
}
