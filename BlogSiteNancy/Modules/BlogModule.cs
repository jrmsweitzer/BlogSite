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
        private BlogService _blogService;
        private UserService _userService;
        private AppViewModel _vm;

        public BlogModule()
            : base("/blog")
        {
            _vm = AppViewModel.GetAppViewModel();
            _blogService = new BlogService();
            _userService = new UserService();

            Get["/"] = _ =>
            {
                return View["Index", _vm.Blogs];
            };

            Get["/{title}"] = parameters =>
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

                if (blog.IsValid())
                {
                    var newBlog = _blogService.AddBlog(blog.ToModel(_userService.GetAnonymousUser()));
                    return View["Details", newBlog];
                }

                //return View["New", blog];
                return null;
            };
        }
    }
}