using Models;
using Nancy.Security;
using System.Collections.Generic;

namespace BlogSiteNancy.Utils
{
    public class AuthenticatedUser : IUserIdentity
    {
        public string UserName { get; set; }
        public IEnumerable<string> Claims { get; set; }
        public User User { get; set; }

        public bool IsAdmin { get { return User.Permission.Name == Utilities.Constants.Permissions.Admin; } }
        public bool IsRegularPoster { get { return User.Permission.Name == Utilities.Constants.Permissions.RegularPoster;} }
        public bool IsBlogCreator { get { return IsAdmin || IsRegularPoster; } }
    }
}