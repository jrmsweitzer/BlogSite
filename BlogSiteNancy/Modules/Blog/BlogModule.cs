using BlogSiteNancy.Modules.Blog.New;
using BlogSiteNancy.Utils;
using BlogSiteNancy.Views.Blog.ViewModels;
using Nancy;
using Nancy.ModelBinding;
using Services.Impl;
using System.Linq;

namespace BlogSiteNancy.Modules
{
    public class BlogModule : NancyModule
    {
        private AppViewModel _vm;

        public BlogModule() : base("/blog")
        {
            _vm = AppViewModel.GetAppViewModel();

            Get["/", runAsync: true] = async (_, token) =>
            {
                return View["Index", _vm.Blogs];
            };

            Get["/{title}/view"] = parameters =>
            {
                var blog = _vm.GetBlogByTitle(parameters.title);

                if (blog == null)
                {
                    return Response.AsRedirect("/");
                }
                else
                {
                    return View["Details", blog];
                }
            };

            Get["/new/"] = _ =>
            {
                return View["New", new NewBlogModel()];
            };

            Post["/new/"] = parameters =>
            {
                var model = this.Bind<NewBlogModel>();
                model.CategoryId = Request.Form["Categories"] - 1;
                var validator = new NewBlogValidator();
                var results = validator.Validate(model);

                var success = results.IsValid;
                var failures = results.Errors;

                if (success)
                {
                    var newBlog = _vm.BlogService.AddBlog(model.ToModel(_vm.LoggedInUser.User.ID));
                    _vm.RefreshBlogs();
                    return View["Details", newBlog];
                }
                return View["New", model];
            };
        }
    }
}