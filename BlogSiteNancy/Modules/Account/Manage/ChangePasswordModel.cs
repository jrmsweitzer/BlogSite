using BlogSiteNancy.Utils;
using Services.Impl;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogSiteNancy.Views.Account.ViewModels
{
    public class ChangePasswordModel : Validatable
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}