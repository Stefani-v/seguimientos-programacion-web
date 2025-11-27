using Microsoft.AspNetCore.Mvc;

namespace TimerApp.Controllers
{
    public class TimerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
