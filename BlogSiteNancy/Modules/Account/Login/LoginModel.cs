using BlogSiteNancy.Utils;

namespace BlogSiteNancy.Views.Account.ViewModels
{
    public class LoginModel : Validatable
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}