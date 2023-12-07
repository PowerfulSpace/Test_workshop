using Microsoft.AspNetCore.Mvc;

namespace DisignProject.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
