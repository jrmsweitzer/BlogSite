namespace AngularNancy
{
    using Nancy;
    using Utilities;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
            {
                return View["Content/index.html"];
            };

            Get["/{*}"] = parameters =>
            {
                return Response.AsRedirect("/#/404");
            };


        }
    }
}