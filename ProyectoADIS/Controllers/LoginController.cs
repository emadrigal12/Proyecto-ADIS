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
        public async Task<IActionResult> IniciarSesion([FromBody] Login l)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SqlConnection con = new SqlConnection(_connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_login", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = l.Usuario;
                            cmd.Parameters.Add("@Clave", SqlDbType.VarChar).Value = l.Password;
                            con.Open();

                            int returnValue = (int)cmd.ExecuteScalar();

                            if (returnValue == 1)
                            {
                                bool changePassword = CheckPrimerLogin(l.Usuario);
                                if (changePassword)
                                {
                                    Response.Cookies.Append("user", "Bienvenido " + l.Usuario);
                                    List<Claim> c = new List<Claim>()
                                    {
                                        new Claim(ClaimTypes.NameIdentifier, l.Usuario)
                                    };
                                    ClaimsIdentity ci = new ClaimsIdentity(c, CookieAuthenticationDefaults.AuthenticationScheme);
                                    AuthenticationProperties p = new AuthenticationProperties();

                                    p.AllowRefresh = true;

                                    p.ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1);

                                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ci), p);

                                    return Ok(new { code = 1, message = "Inicio de sesión exitoso." }); 
                                }
                                else
                                {
                                    return Ok(new { code = 2, message = "Inicio de sesión exitoso, pero debe cambiar la contraseña." });
                                }
                            }
                            else
                            {
                                return Ok(new { code = 3, message = "Usuario y contraseña inválidos, reintente nuevamente." });
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest("Error interno."); // Error interno del servidor
            }

            return BadRequest("Error de credenciales."); // Error de credenciales
        }



        public bool CheckPrimerLogin(string usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool firstLogin = false;
                    using (SqlConnection con = new SqlConnection(_connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_check_first_login", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = usuario;

                            con.Open();

                            int returnValue = (int)cmd.ExecuteScalar();

                            if (returnValue == 1)
                            {
                                firstLogin = true;
                            }
                            else
                            {
                                ViewData["error"] = "Error de credenciales";
                            }
                            con.Close();
                        }
                    }
                    return firstLogin;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;


        }

        [HttpPut]
        public async Task<IActionResult> UpdatePassword([FromBody] Login l)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SqlConnection con = new SqlConnection(_connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_update_password", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = l.Usuario;
                            cmd.Parameters.Add("@Contrasena_Actual", SqlDbType.VarChar).Value = l.actualPassword;
                            cmd.Parameters.Add("@Contrasena_Nueva", SqlDbType.VarChar).Value = l.newPassword;

                            con.Open();
                            int returnValue = (int)cmd.ExecuteScalar();
                            con.Close();
                            if (returnValue == 1)
                            {
                                return Ok(new { code = 1, message = "Inicio de sesión exitoso." });
                            }else
                            {
                            }
                                return Ok(new { code = 2, message = "Error al cambiar contrasena" });
                        }
                    }
                }
            }
            catch (Exception)
            {
                return Ok(new { code = 2, message = "Error desconocido." });
            }
            return Ok(new { code = 2, message = "Error desconocido." }); 


        }
    }
}
