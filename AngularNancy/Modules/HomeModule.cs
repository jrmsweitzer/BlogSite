namespace AngularNancy
{
    using Nancy;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
            {
                return View["Content/index.html"];
            };
        }
    }
}