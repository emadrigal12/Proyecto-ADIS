using Microsoft.AspNetCore.Mvc;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using dotenv.net;

namespace ProyectoADIS.Controllers
{
    public class CursoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detalle()
        {
            return View();
        }

        
    }
}
