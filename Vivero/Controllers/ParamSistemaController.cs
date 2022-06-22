using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
namespace Vivero.Controllers
{
    public class ParamSistemaController : Controller
    {
        private readonly IRepositorioParamSistema _repositorioParamSistema;

        public ParamSistemaController(IRepositorioParamSistema repositorioParamSistema)
        {
            _repositorioParamSistema = repositorioParamSistema;
        }

        /* CONEXION ANTERIOR
        IRepositorio<ParamSistema> repositorio = new RepositorioParamSistema_old(new Connection());
        */


        // GET: ParamSistemaController
        public ActionResult Index()
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                return View(_repositorioParamSistema.Get());
            }

            return Redirect("/Login/Login");
        }

        // GET: ParamSistemaController/Details/5
        public ActionResult Details(int id)
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                return View();
            }

            return Redirect("/Login/Login");
        }

        // GET: ParamSistemaController/Create
        public ActionResult Create()
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                return View();
            }

            return Redirect("/Login/Login");
        }

        // POST: ParamSistemaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                try
                {
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ViewBag.Mensaje = "ERROR: No se pudo completar la acción";
                    return View("ErrorAlta");
                }
            }

            return Redirect("/Login/Login");
        }

        // GET: ParamSistemaController/Edit/5
        public ActionResult Edit(int id)
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                ParamSistema unParam = _repositorioParamSistema.GetByID(id);
                return View(unParam);
            }

            return Redirect("/Login/Login");
        }

        // POST: ParamSistemaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ParamSistema unParam)
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                try
                {
                    _repositorioParamSistema.Update(unParam);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ViewBag.Mensaje = "ERROR: No se pudo completar la acción";
                    return View("ErrorAlta");
                }
            }

            return Redirect("/Login/Login");
        }

        // GET: ParamSistemaController/Delete/5
        public ActionResult Delete(int id)
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                return View();
            }

            return Redirect("/Login/Login");
        }

        // POST: ParamSistemaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                try
                {
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ViewBag.Mensaje = "ERROR: No se pudo completar la acción";
                    return View("ErrorAlta");
                }
            }

            return Redirect("/Login/Login");
        }
    }
}
