using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProyectoADIS.Models;
using System;
using System.Data;
using System.Security.Claims;

namespace ProyectoADIS.Controllers
{
    
    public class LoginController : Controller
    {

        private readonly AplicationDBContext _context;
        private readonly string _connectionString;

        public LoginController(AplicationDBContext context)
        {
            _context = context;
            _connectionString = _context.Database.GetConnectionString();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesiones(Login model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == model.Usuario && u.Contrasena == model.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View(model);
            }

            // Aquí puedes establecer la sesión, generar el token de autenticación, redireccionar a una página de inicio, etc.

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion([FromBody] Login l)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SqlConnection con = new(_connectionString))
                    {
                        using (SqlCommand cmd = new("sp_login", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = l.Usuario;
                            cmd.Parameters.Add("@Clave", SqlDbType.VarChar).Value = l.Password;
                            con.Open();

                            SqlDataReader dr = cmd.ExecuteReader();

                            if (dr.Read())
                            {
                                Response.Cookies.Append("user", "Bienvenido " + l.Usuario);
                                List<Claim> c = new List<Claim>()
                                {
                                    new Claim(ClaimTypes.NameIdentifier, l.Usuario)
                                };
                                ClaimsIdentity ci = new(c, CookieAuthenticationDefaults.AuthenticationScheme);
                                AuthenticationProperties p = new();

                                p.AllowRefresh = true;

                                p.ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1);

                                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ci), p);
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                ViewData["error"] = "Error de credenciales";
                            }

                            

                            con.Close();
                        }
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception)
            {
                return View("Login");
            }
            return View("Login");
        }


        public IActionResult CheckPrimerLogin()
        {
            // Supongamos que tienes una propiedad en tu contexto de base de datos que representa el usuario actual
            var user = _context.Usuarios.FirstOrDefault(u => u.Correo == User.Identity.Name);

            if (user != null && user.CambioContrasena == "S")
            {
                return Json(new { primerLogin = true });
            }

            return Json(new { primerLogin = false });
        }
    }
}
