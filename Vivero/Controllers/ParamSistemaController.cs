﻿using DataAcces;
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
            return View(repositorio.Get());
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
            ParamSistema unParam = repositorio.GetByID(id);
            return View(unParam);
        }

        // POST: ParamSistemaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ParamSistema unParam)
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