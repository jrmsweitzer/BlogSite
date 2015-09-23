using OpenQA.Selenium;
using Selenium.PageObjects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Selenium.PageObjects
{
    public class ChangePasswordPO : ValidatablePageObject
    {
        public ChangePasswordPO(IWebDriver driver) : base(driver)
        {
            _url = Constants.Urls.Account.ChangePassword;
            GoTo(_url);
        }

        // Locators
        private static readonly By OldPasswordTextbox = By.Id("OldPassword");
        private static readonly By NewPasswordTextbox = By.Id("NewPassword");
        private static readonly By ConfirmNewPasswordTextbox = By.Id("ConfirmNewPassword");
        private static readonly By SubmitBtn = By.Id("ChangePasswordBtn");

        // Validation Errors
        private static readonly By MissingOldPasswordError =
            Error.Format(Constants.Messages.Account.ChangePassword.MissingOldPassword);
        private static readonly By MissingNewPasswordError =
            Error.Format(Constants.Messages.Account.ChangePassword.MissingNewPassword);
        private static readonly By MissingConfirmNewPasswordError =
            Error.Format(Constants.Messages.Account.ChangePassword.MissingConfirmNewPassword);
        private static readonly By InvalidOldPasswordError =
            Error.Format(Constants.Messages.Account.ChangePassword.InvalidOldPassword);
        private static readonly By MismatchedNewPasswordsError =
            Error.Format(Constants.Messages.Account.ChangePassword.MismatchedPasswords);

        public ChangePasswordPO ChangePassword(string oldPassword, string newPassword, string confirmNewPassword)
        {
            SendKeys(OldPasswordTextbox, oldPassword);
            SendKeys(NewPasswordTextbox, newPassword);
            SendKeys(ConfirmNewPasswordTextbox, confirmNewPassword);
            Click(SubmitBtn);
            return this;
        }

        public bool IsOldPasswordErrorPresent()
        {
            return FindAll(MissingOldPasswordError).Count > 0;
        }

        public bool IsNewPasswordErrorPresent()
        {
            return FindAll(MissingNewPasswordError).Count > 0;
        }

        public bool IsConfirmNewPasswordErrorPresent()
        {
            return FindAll(MissingConfirmNewPasswordError).Count > 0;
        }

        public bool IsInvalidPasswordErrorPresent()
        {
            return FindAll(InvalidOldPasswordError).Count > 0;
        }

        public bool IsMismatchedPasswordsErrorPresent()
        {
            return FindAll(MismatchedNewPasswordsError).Count > 0;
        }
    }
}
