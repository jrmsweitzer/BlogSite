using Nancy;
using Nancy.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSiteNancy.Modules
{
    public class AdminModule : NancyModule
    {
        public AdminModule()
        {
            this.RequiresAuthentication();
            this.RequiresClaims(new[] { Utilities.Constants.Permissions.Admin });
        }
    }
}