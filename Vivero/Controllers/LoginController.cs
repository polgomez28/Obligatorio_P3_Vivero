using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vivero.Controllers
{
    public class LoginController : Controller
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public LoginController(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }
        /* CONEXION ANTERIOR
        IRepositorioUsuario repositorioUsuario = new RepositorioUsuario_old(new Connection());
        */

        public ActionResult Login(string mensaje)
        {
            ViewBag.mensaje = mensaje;
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            if (ModelState.IsValid && ValidateUser(usuario))
            {
                HttpContext.Session.SetString("Name", usuario.Email);
                HttpContext.Session.SetString("Logeado", true.ToString());
                return Redirect("/Planta/Index");
            }

            return RedirectToAction("Login", new { mensaje = "Usuario o Contraseña incorrecta" });
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/Login/Login");
        }

        private bool ValidateUser(Usuario usuario)
        {
            var usuarios = _repositorioUsuario.GetUsuarios();
            foreach (var usu in usuarios)
            {
                if (usu.Email.Equals(usuario.Email) && usu.Contraseña.Equals(usuario.Contraseña))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
