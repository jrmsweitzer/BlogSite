using BlogSiteNancy.Views.Account.ViewModels;
using FluentValidation;
using Utilities;

namespace BlogSiteNancy.Modules.Account.Login
{
    public class LoginValidator : AbstractValidator<LoginModel>
    {
        public LoginValidator()
        {
            RuleFor(model => model.Username).NotEmpty().WithMessage(Constants.Messages.Account.Login.MissingUsername);
            RuleFor(model => model.Password).NotEmpty().WithMessage(Constants.Messages.Account.Login.MissingPassword);
        }
    }
}