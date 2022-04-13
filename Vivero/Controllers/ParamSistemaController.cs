using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vivero.Controllers
{
    public class ParamSistemaController : Controller
    {
        // GET: ParamSistemaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ParamSistemaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ParamSistemaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParamSistemaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ParamSistemaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ParamSistemaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: ParamSistemaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ParamSistemaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
