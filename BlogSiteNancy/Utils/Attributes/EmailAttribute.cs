using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace BlogSiteNancy.Utils
{
    public class EmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var email = value as string;
            var emailSplit = email.Split('@');

            if (emailSplit.Length != 2 ||
                emailSplit[0].Length == 0 ||
                emailSplit[1].Length < 2 ||
                emailSplit[1].Length > 5)
            {
                return new ValidationResult(this.ErrorMessage = "Please input a valid email.");
            }

            return ValidationResult.Success;
        }
    }
}