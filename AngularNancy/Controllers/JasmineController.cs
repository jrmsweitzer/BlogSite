using Nancy;

namespace AngularNancy.Controllers
{
    public class JasmineController : NancyModule
    {
        public JasmineController()
        {
            Get["/Run"] = _ =>
            {
                return View["SpecRunner"];
            };
        }
    }
}
