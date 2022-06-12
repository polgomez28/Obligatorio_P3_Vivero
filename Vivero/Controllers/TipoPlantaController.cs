﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace Vivero.Controllers
{
    public class TipoPlantaController : Controller
    {
        private readonly IRepositorioTipoPlanta _repositorioTipoPlanta;

        public TipoPlantaController(IRepositorioTipoPlanta repositorioTipoPlanta)
        {
            _repositorioTipoPlanta = repositorioTipoPlanta;
        }
        /* CONEXION VIEJA
        IRepositorioPlanta repositorio = new RepositorioPlanta_old(new Connection());
        IRepositorio<ParamSistema> repositorioParam = new RepositorioParamSistema_old(new Connection());
        // GET: TipoPlantaController
        */

        public ActionResult Index()
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                return View(_repositorioTipoPlanta.GetType());
            }
            return Redirect("/Login/Login");
        }

        // GET: TipoPlantaController/Details/5
        public ActionResult Details(int id)
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                return View();
            }

            return Redirect("/Login/Login");
        }

        // GET: TipoPlantaController/Create
        public ActionResult Create()
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                return View();
            }

            return Redirect("/Login/Login");
        }

        // POST: TipoPlantaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoPlanta unTipo)
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                try
                {
                    ICollection<ParamSistema> resultado = new List<ParamSistema>();
                    //resultado = (ICollection<ParamSistema>)repositorioParam.Get();
                    int numMin = 0, numMax = 0;
                    foreach (ParamSistema item in resultado)
                    {
                        if (item.Nombre.Equals("TipoDesc"))
                        {
                            numMax = item.ValorMax;
                            numMin = item.ValorMin;
                        }
                    }
                    if (TipoPlanta.DescValid(unTipo.TipoDesc, numMax, numMin))
                    {
                        if (TipoPlanta.QuitarEspacios(unTipo.TipoNombre))
                        {
                            try
                            {
                                //bool exist = _repositorioTipoPlanta.InsertTipo(unTipo);
                                //if (!exist)
                                //{                                    
                                //    return View("SuccessAlta");
                               // }
                                //else
                                //{
                                 //   return View("ErrorAlta");
                                //}
                                
                            }
                            catch (Exception ex)
                            {
                                return View("ErrorAlta");
                            }
                        }
                        else
                        {
                            return View("ErrorAlta");
                        }
                    }
                    else
                    {
                        return View("ErrorAlta");
                    }
                }
                catch
                {
                    return View("ErrorAlta");
                }
            }

            return Redirect("/Login/Login");
        }

        // GET: TipoPlantaController/Edit/5
        public ActionResult Edit(int id)
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {

                //TipoPlanta unTipo = repositorio.GetByIdTipo(id);
                //return View(unTipo);
            }

            return Redirect("/Login/Login");
        }

        // POST: TipoPlantaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoPlanta unTipo)
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                try
                {
                    ICollection<ParamSistema> resultado = new List<ParamSistema>();
                    //resultado = (ICollection<ParamSistema>)repositorioParam.Get();
                    int numMin = 0, numMax = 0;
                    foreach (ParamSistema item in resultado)
                    {
                        if (item.Nombre.Equals("TipoDesc"))
                        {
                            numMax = item.ValorMax;
                            numMin = item.ValorMin;
                        }
                    }
                    if (TipoPlanta.DescValid(unTipo.TipoDesc, numMax, numMin))
                    {
                        if (TipoPlanta.QuitarEspacios(unTipo.TipoNombre))
                        {
                            try
                            {
                                //repositorio.UpdateTipo(unTipo);
                                return View("SuccessAlta");
                            }
                            catch (Exception ex)
                            {
                                return View("ErrorAlta");
                            }
                        }
                        else
                        {
                            return View("ErrorAlta");
                        }
                    }
                    else
                    {
                        return View("ErrorAlta");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return Redirect("/Login/Login");
        }

        // GET: TipoPlantaController/Delete/5
        public ActionResult Delete(int id)
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                //TipoPlanta unTipo = repositorio.GetByIdTipo(id);
                //return View(unTipo);
            }

            return Redirect("/Login/Login");
        }

        // POST: TipoPlantaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTipo(int IdTipoPlanta)
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                try
                {
                    //repositorio.DeleteTipo(IdTipoPlanta);
                    return View("SuccessAlta");
                }
                catch
                {
                    return View("ErrorAlta");
                }
            }

            return Redirect("/Login/Login");
        }
        public ActionResult Search()
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                return View();
            }

            return Redirect("/Login/Login");
        }
        [HttpPost]
        public ActionResult Search(string TipoNombre)
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                try

                {
                    //TipoPlanta unTipo = repositorio.GetByNombreTipo(TipoNombre);
                    /*
                    if (unTipo == null)
                    {
                        return View("ErrorAlta");
                    }
                    else
                    {
                        return View("ViewSearch", unTipo);
                    }
                    */
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return Redirect("/Login/Login");
        }
    }
}
