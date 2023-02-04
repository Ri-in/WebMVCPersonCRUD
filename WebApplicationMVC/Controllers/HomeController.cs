using Microsoft.AspNetCore.Mvc;

namespace WebApplicationMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
