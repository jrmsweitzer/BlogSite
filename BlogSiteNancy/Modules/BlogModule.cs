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

            Get["/"] = _ =>
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

            Post["/new/"] = _ =>
            {
                NewBlogModel blog = this.Bind<NewBlogModel>();
                blog.Category = _vm.Categories[Request.Form["Categories"] - 1];

                if (blog.IsValid())
                {
                    var newBlog = _vm.BlogService.AddBlog(blog.ToModel(_vm.UserService.GetAnonymousUser()));
                    _vm.RefreshBlogs();
                    return View["Details", newBlog];
                }

                //return View["New", blog];
                return null;
            };
        }
    }
}