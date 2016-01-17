using BlogSiteNancy.Utils;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utilities;

namespace BlogSiteNancy.Modules.Tags
{
    public class TagsModule : NancyModule
    {
        private AppViewModel _vm;

        public TagsModule() : base("/tags")
        {
            _vm = AppViewModel.GetAppViewModel();
        }
    }
}