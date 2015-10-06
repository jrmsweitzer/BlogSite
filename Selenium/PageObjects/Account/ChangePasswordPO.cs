using OpenQA.Selenium;
using Selenium.PageObjects.Base;
using Utilities;
using ChangePasswordMessages = Utilities.Constants.Messages.Account.Manage;

namespace Selenium.PageObjects
{
    public class ChangePasswordPO : ValidatablePageObject
    {
        public ChangePasswordPO(IWebDriver driver) : base(driver)
        {
            _url = Constants.Urls.Account.Manage;
            GoTo(_url);
        }

        // Locators
        private static readonly By OldPassword = By.Id("ManageOldPassword");
        private static readonly By NewPassword = By.Id("ManageNewPassword");
        private static readonly By ConfirmPassword = By.Id("ManageConfirmNewPassword");
        private static readonly By SubmitButton = By.Id("ChangePasswordButton");

        // Validation Errors
        private static readonly By MissingOldPassword = Error.Format(
            ChangePasswordMessages.MissingOldPassword);

        private static readonly By MissingNewPassword = Error.Format(
            ChangePasswordMessages.MissingNewPassword);

        private static readonly By MissingConfirmNewPassword = Error.Format(
            ChangePasswordMessages.MissingConfirmNewPassword);

        private static readonly By InvalidOldPassword =Error.Format(
            ChangePasswordMessages.InvalidOldPassword);

        private static readonly By MismatchedPasswords =Error.Format(
            ChangePasswordMessages.MismatchedPasswords);

        public ChangePasswordPO ChangePassword(
            string oldPassword, string newPassword, string confirmPassword)
        {
            SendKeys(OldPassword, oldPassword);
            SendKeys(NewPassword, newPassword);
            SendKeys(ConfirmPassword, confirmPassword);
            Click(SubmitButton);
            return this;
        }

        public bool IsOldPasswordErrorPresent()
        {
            return FindAll(MissingOldPassword).Count > 0;
        }

        public bool IsNewPasswordErrorPresent()
        {
            return FindAll(MissingNewPassword).Count > 0;
        }

        public bool IsConfirmNewPasswordErrorPresent()
        {
            return FindAll(MissingConfirmNewPassword).Count > 0;
        }

        public bool IsInvalidPasswordErrorPresent()
        {
            return FindAll(InvalidOldPassword).Count > 0;
        }

        public bool IsMismatchedPasswordsErrorPresent()
        {
            return FindAll(MismatchedPasswords).Count > 0;
        }
    }
}
