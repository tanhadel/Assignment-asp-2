using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}
