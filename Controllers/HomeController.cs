using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversity.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
