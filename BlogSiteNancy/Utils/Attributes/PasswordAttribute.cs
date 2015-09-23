using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace BlogSiteNancy.Utils
{
    public class PasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            const int MIN_LENGTH = 8;
            var password = value as string;
            var success = true;
            var builder = new StringBuilder();

            if (string.IsNullOrEmpty(password))
            {
                success = false;
                builder.Append("You need to input a password here. ");
            }

            bool meetsLengthRequirements = password.Length >= MIN_LENGTH;
            bool hasUpperCaseLetter = false;
            bool hasLowerCaseLetter = false;
            bool hasDecimalDigit = false;

            if (!meetsLengthRequirements)
            {
                success = false;
                builder.Append(string.Format("You need at least {0} characters in your password. ", MIN_LENGTH));
            }
            else
            {
                foreach (char c in password)
                {
                    if (char.IsUpper(c)) hasUpperCaseLetter = true;
                    else if (char.IsLower(c)) hasLowerCaseLetter = true;
                    else if (char.IsDigit(c)) hasDecimalDigit = true;
                }
            }

            if (!hasUpperCaseLetter)
            {
                success = false;
                builder.Append("Your password must contain an Upper Case letter. ");
            }
            if (!hasLowerCaseLetter)
            {
                success = false;
                builder.Append("Your password must contain a Lower Case letter. ");
            }
            if (!hasDecimalDigit)
            {
                success = false;
                builder.Append("Your password must contain at least one digit. ");
            }

            bool isValid = success &&
                hasUpperCaseLetter &&
                hasLowerCaseLetter &&
                hasDecimalDigit;

            if (isValid)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(
                this.ErrorMessage = builder.ToString());
            }
        }
    }
}