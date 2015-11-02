using BlogSiteNancy.Utils;
using BlogSiteNancy.Views.Shared.ViewModels;
using BlogSiteNancy.Views.User.ViewModels;
using Nancy;
using Services.Impl;
using Utilities;

namespace BlogSiteNancy.Modules
{
    public class UserModule : NancyModule
    {
        private AppViewModel _vm;

        public UserModule() : base("/user")
        {
            _vm = AppViewModel.GetAppViewModel();

            Get["/{username}"] = parameters =>
            {
                var user = _vm.UserService.GetUserByUserName(parameters.username);

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
                Models.User user = _vm.UserService.GetUserByUserName(parameters.username);
                if (user == null)
                {
                    return Response.AsRedirect("404");
                }

                var blogsByUser = _vm.BlogService.GetBlogsByUsername(user.UserName);
                if (blogsByUser == null || blogsByUser.Count == 0)
                {
                    return Response.AsRedirect("404");
                }

                return View["blog/Index", blogsByUser];
            };
        }
    }
}