using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularNancy.ViewModels
{
    public class PasswordDTO
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string Username { get; set; }
    }
}