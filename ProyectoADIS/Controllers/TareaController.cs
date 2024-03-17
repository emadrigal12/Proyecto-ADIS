using Microsoft.AspNetCore.Mvc;

namespace ProyectoADIS.Controllers
{
    public class TareaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
