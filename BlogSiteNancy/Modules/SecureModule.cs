using Nancy;
using Nancy.Security;

namespace BlogSiteNancy.Modules
{
    public class SecureModule : NancyModule
    {
        public SecureModule()
        {
            this.RequiresAuthentication();
            Get["/secure"] = _ =>
            {
                return "I'm secure!";
            };
        }
    }
}