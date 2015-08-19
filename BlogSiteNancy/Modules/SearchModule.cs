using BlogSiteNancy.Views.Shared.ViewModels;
using Nancy;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSiteNancy.Modules
{
    public class SearchModule : NancyModule
    {
        public SearchModule() : base("/search")
        {
            //Post["/"] = _ =>
            //{
            //    _LayoutModel model = this.Bind<_LayoutModel>();
            //};
        }
    }
}