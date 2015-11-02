using OpenQA.Selenium;
using Selenium.PageObjects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.PageObjects.Account
{
    public class RegisterPageObject : ValidatablePageObject
    {
        public RegisterPageObject(IWebDriver driver) : base(driver)
        {
            // DO NOTHING
        }

        // Locators
        private static readonly By UsernameTextBox = By.Id("RegisterUsername");
        private static readonly By PasswordTextBox = By.Id("RegisterPassword");
        private static readonly By ConfirmPasswordTextBox = 
            By.Id("RegisterConfirmPassword");
        private static readonly By RegisterButton = By.Id("RegisterButton");

        public IBlogPage Register(
            string username, string password, string confirmPassword)
        {
            ClearAndSendKeys(UsernameTextBox, username);
            ClearAndSendKeys(PasswordTextBox, password);
            ClearAndSendKeys(ConfirmPasswordTextBox, confirmPassword);
            Click(RegisterButton);
            if (GetErrorCount() == 0)
            {
                return new HomePageObject(_driver);
            }
            return this;
        }
    }
}
