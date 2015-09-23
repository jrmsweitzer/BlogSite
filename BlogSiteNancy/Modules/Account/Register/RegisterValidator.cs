using BlogSiteNancy.Views.Account.ViewModels;
using FluentValidation;

namespace BlogSiteNancy.Views.Account.Validators
{
    public class RegisterValidator : FluentValidation.AbstractValidator<RegisterModel>
    {
        public RegisterValidator()
        {
            RuleFor(user => user.Username).NotEmpty();
            RuleFor(user => user.Username).EmailAddress();
            RuleFor(user => user.Password).NotEmpty();
            RuleFor(user => user.ConfirmPassword).NotEmpty();
            RuleFor(user => user.Password).Must(BeAValidPassword).WithMessage("Password must contain at least one number, one uppercase, and one lowercase letter.");
        }

        private bool BeAValidPassword(string password)
        {
            const int MIN_LENGTH = 8;

            bool meetsLengthRequirements = password != null && password.Length >= MIN_LENGTH;
            bool hasUpperCaseLetter = false;
            bool hasLowerCaseLetter = false;
            bool hasDecimalDigit = false;

            if (meetsLengthRequirements)
            {
                foreach (char c in password)
                {
                    if (char.IsUpper(c)) hasUpperCaseLetter = true;
                    else if (char.IsLower(c)) hasLowerCaseLetter = true;
                    else if (char.IsDigit(c)) hasDecimalDigit = true;
                }
            }

            return hasUpperCaseLetter &&
                hasLowerCaseLetter &&
                hasDecimalDigit;
        }
    }
}