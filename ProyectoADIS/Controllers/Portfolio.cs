using Microsoft.AspNetCore.Mvc;

namespace ProyectoADIS.Controllers
{
    public class Portfolio : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
