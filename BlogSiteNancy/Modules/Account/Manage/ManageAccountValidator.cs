﻿using BlogSiteNancy.Views.Account.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSiteNancy.Modules.Account.Manage
{
    public class ManageAccountValidator : AbstractValidator<ManageAccountModel>
    {
        public ManageAccountValidator()
        {
            RuleFor(model => model.OldPassword).NotEmpty();
            RuleFor(model => model.NewPassword).NotEmpty();
            RuleFor(model => model.ConfirmNewPassword).NotEmpty();
        }
    }
}