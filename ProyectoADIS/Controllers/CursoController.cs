using Microsoft.AspNetCore.Mvc;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using dotenv.net;
using Microsoft.AspNetCore.Authorization;
using ProyectoADIS.Models;
using ProyectoADIS.Migrations;
using ProyectoADIS.Entities;
using System.Collections.Generic;

namespace ProyectoADIS.Controllers
{
    [Authorize]
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

        public IActionResult Asistencia()
        {
            var estudiantes = new List<Usuario>
            {
                new Usuario { Id = 1, Nombre = "Estudiante 1" },
                new Usuario { Id = 2, Nombre = "Estudiante 2" },
                new Usuario { Id = 3, Nombre = "Estudiante 3" }
                // Puedes agregar más estudiantes aquí si lo deseas
            };

            return View(estudiantes);
        }


    }
}
