using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Security;
using Services.Impl;
using System;

namespace BlogSiteNancy.Utils
{
    public class DatabaseUser : IUserMapper
    {
        private UserService _userService;
        public DatabaseUser()
        {
            _userService = new UserService();
        }

        public IUserIdentity GetUserFromIdentifier(Guid identifier, NancyContext context)
        {
            var member = _userService.GetUserByGUID(identifier);

            if (member == null)
            {
                return null;
            }

            return new AuthenticatedUser
            {
                UserName = member.UserName,
                Claims = new[]
                {
                    member.Permission.Name
                },
                User = member
            };
        }
    }
}