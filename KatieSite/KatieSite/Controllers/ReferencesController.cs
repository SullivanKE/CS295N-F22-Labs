using Microsoft.AspNetCore.Mvc;

namespace KatieSite
{
    public class ReferencesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Books()
        {
            return View();
        }

        public IActionResult Links()
        {
            return View();
        }
    }
}
