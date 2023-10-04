using Microsoft.AspNetCore.Mvc;

namespace KabaImmo.Controllers
{
    public class WebsiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
