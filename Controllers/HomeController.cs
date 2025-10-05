using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversity101.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
