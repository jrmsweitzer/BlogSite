using BlogSiteNancy.Modules.Account.Login;
using BlogSiteNancy.Modules.Account.Manage;
using BlogSiteNancy.Utils;
using BlogSiteNancy.Views.Account.Validators;
using BlogSiteNancy.Views.Account.ViewModels;
using BlogSiteNancy.Views.Shared.ViewModels;
using FluentValidation.Results;
using Models;
using Nancy;
using Nancy.ModelBinding;
using System.Collections.Generic;
using Utilities;

namespace BlogSiteNancy.Modules
{
    public class AccountModule : NancyModule
    {
        public AccountModule()
            : base("/account")
        {
            var _vm = AppViewModel.GetAppViewModel();

            #region GETS
            Get["/login"] = parameters => { return View["Login", new LoginModel()]; };
            Get["/manage"] = parameters =>
            {
                if (_vm.LoggedInUser != null)
                {
                    return View["Manage", new ManageAccountModel()];
                }
                else
                {
                    return View[Constants.ViewLocations._404, new _404Model("The webpage you are looking for has moved or does not exist.")];
                }
            };
            Get["/logout"] = parameters => { return Nancy.Authentication.Forms.ModuleExtensions.LogoutAndRedirect(this, "/"); };
            Get["/register"] = parameters => { return View["Register", new RegisterModel()]; };
            #endregion

            #region POSTS
            #region /account/login
            Post["/login"] = parameters =>
            {
                var model = this.Bind<LoginModel>();
                var validator = new LoginValidator();
                var results = validator.Validate(model);

                var success = results.IsValid;
                var failures = results.Errors;

                if (success)
                {
                    var user = _vm.UserService.GetUserByUserName(model.Username);

                    if (user == null || !_vm.EncryptionService.ValidatePassword(model.Password, user.HashedPassword))
                    {
                        ValidationFailure failure = new ValidationFailure("Username,Password", 
                            Constants.Messages.Account.Login.MismatchedUsernamePassword);
                        model.Failures = new List<ValidationFailure>() { failure };
                        return View["login", model];
                    }

                    return Nancy.Authentication.Forms.ModuleExtensions.LoginAndRedirect(this, System.Guid.Parse(user.GUID), null, "/");
                }
                model.Failures = failures;
                return View["login", model];
            };
            #endregion
            #region /account/changepassword
            Post["/changepassword"] = parameters =>
            {
                var model = this.Bind<ManageAccountModel>();
                var validator = new ManageAccountValidator();
                var results = validator.Validate(model);

                var success = results.IsValid;
                var failures = results.Errors;

                if (success)
                {
                    if (model.NewPassword != model.ConfirmNewPassword)
                    {
                        var failure = new ValidationFailure("NewPassword,ConfirmNewPassword",
                            Constants.Messages.Account.Manage.MismatchedPasswords);
                        model.Failures = new List<ValidationFailure>() { failure };
                        return View["manage", model];
                    }
                    if (!_vm.EncryptionService.ValidatePassword(model.OldPassword, _vm.LoggedInUser.User.HashedPassword))
                    {
                        var failure = new ValidationFailure("OldPassword",
                            Constants.Messages.Account.Manage.InvalidOldPassword);
                        model.Failures = new List<ValidationFailure>() { failure };
                        return View["manage", model];
                    }
                    _vm.UserService.ChangeUserPassword(_vm.LoggedInUser.User.ID, _vm.EncryptionService.CreateHash(model.NewPassword));
                    var successMessage = Constants.Messages.Account.Manage.SuccessPasswordChanged;
                    model.Successes = new List<string>() { successMessage };
                    model.Failures.Clear();
                    _vm.LoggedInUser.User = _vm.UserService.GetUserById(_vm.LoggedInUser.User.ID);
                    return View["manage", model];
                }
                return View["manage", model];
            };
            #endregion
            #region /account/register
            Post["/register"] = parameters =>
            {
                var model = this.Bind<RegisterModel>();
                var validator = new RegisterValidator();
                var results = validator.Validate(model);

                var success = results.IsValid;
                var failures = results.Errors;

                if (success)
                {
                    if (!model.Password.Equals(model.ConfirmPassword))
                    {
                        model.Failures.Add(new ValidationFailure("Password,ConfirmPassword",
                            Constants.Messages.Account.Register.MismatchedPasswords));
                    }
                    var user = _vm.UserService.GetUserByUserName(model.Username);
                    if (user != null)
                    {
                        model.Failures.Add(new ValidationFailure("Username", string.Format(
                            Constants.Messages.Account.Register.UserExists, model.Username)));
                    }
                    if (model.Failures.Count != 0)
                    {
                        return View["register", model];
                    }
                    user = _vm.UserService.AddUser(
                        new User(
                            model.Username,
                            _vm.EncryptionService.CreateHash(model.Password),
                            _vm.PermissionService.GetPermissionByName(Constants.Permissions.User).ID));

                    return Nancy.Authentication.Forms.ModuleExtensions.LoginAndRedirect(this, System.Guid.Parse(user.GUID), null, "/");
                }
                model.Failures = failures;
                return View["register", model];
            };
            #endregion
            #endregion
        }
    }
}