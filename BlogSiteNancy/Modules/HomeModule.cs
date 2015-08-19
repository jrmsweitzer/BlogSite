using BlogSiteNancy.Utils;
using BlogSiteNancy.Views.Shared.ViewModels;
using Nancy;
using Services.Impl;

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
                var blogs = _vm.Blogs;

                if (blogs != null && blogs.Count > 0)
                {
                    return View["Index"];
                }
                else
                {
                    return View["shared/404"];
                }
            };

            Get["/{*}"] = parameters =>
            {
                return View["shared/404", new _404Model("The webpage you are looking for has moved or does not exist.")];
            };
        }
    }
}