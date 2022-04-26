using DataAcces;
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
        IRepositorio<ParamSistema> repositorio = new RepositorioParamSistema(new Connection());
        // GET: ParamSistemaController
        public ActionResult Index()
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                return View(repositorio.Get());
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
                    return View();
                }
            }

            return Redirect("/Login/Login");
        }

        // GET: ParamSistemaController/Edit/5
        public ActionResult Edit(int id)
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                ParamSistema unParam = repositorio.GetByID(id);
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
                    repositorio.Update(unParam);
                    return View("SuccessAlta");
                }
                catch
                {
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
                    return View();
                }
            }

            return Redirect("/Login/Login");
        }
    }
}
