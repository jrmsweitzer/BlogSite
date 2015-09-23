using BlogSiteNancy.Utils;
using BlogSiteNancy.Views.Shared.ViewModels;
using Nancy;
using Services.Impl;
using Utilities;

namespace BlogSiteNancy.Modules
{
    public class HomeModule : NancyModule
    {
        private AppViewModel _vm;

        public HomeModule()
        {
            _vm = AppViewModel.GetAppViewModel();

            Get["/"] = _ =>
            {
                _vm.LoggedInUser = this.Context.CurrentUser as AuthenticatedUser;

                var blogs = _vm.Blogs;

                if (blogs != null)
                {
                    return View["Index"];
                }
                else
                {
                    return View[Constants.ViewLocations._404, new _404Model("There are currently no blogs to display!")];
                }
            };

            Get["/{*}"] = parameters =>
            {
                return View[Constants.ViewLocations._404, new _404Model("The webpage you are looking for has moved or does not exist.")];
            };
        }
    }
}