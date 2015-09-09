using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSiteNancy.Modules
{
    public class AccountModule : NancyModule
    {
        public AccountModule()
            : base("/account")
        {
            Get["/login"] = _ =>
            {
                return View["Login"];
            };

            Get["/register"] = _ =>
            {
                return View["Register"];
            };
        }
    }
}