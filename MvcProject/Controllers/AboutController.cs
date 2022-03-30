using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    [Route("about")]
    public class AboutController : Controller
    {

        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
