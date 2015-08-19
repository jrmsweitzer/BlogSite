using BlogSiteNancy.Views.Shared.ViewModels;
using BlogSiteNancy.Views.User.ViewModels;
using Nancy;
using Services.Impl;

namespace BlogSiteNancy.Modules
{
    public class UserModule : NancyModule
    {
        private UserService _userService;
        private BlogService _blogService;

        public UserModule() : base("/user")
        {
            _userService = new UserService();
            _blogService = new BlogService();

            Get["/{username}"] = parameters =>
            {
                var user = _userService.GetUserByUserName(parameters.username);

                if (user == null)
                {
                    return Response.AsRedirect("/");
                }
                else
                {
                    return View["Details", new DetailsModel(user)];
                }
            };

            Get["/{username}/allblogs"] = parameters =>
            {
                Models.User user = _userService.GetUserByUserName(parameters.username);
                if (user == null)
                {
                    return Response.AsRedirect("404");
                }

                var blogsByUser = _blogService.GetBlogsByUsername(user.UserName);
                if (blogsByUser == null || blogsByUser.Count == 0)
                {
                    return Response.AsRedirect("404");
                }

                return View["blog/Index", blogsByUser];
            };
        }
    }
}