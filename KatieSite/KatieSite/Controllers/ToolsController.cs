using Microsoft.AspNetCore.Mvc;

namespace KatieSite.Controllers
{
    public class ToolsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
