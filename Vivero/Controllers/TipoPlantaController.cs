using Microsoft.AspNetCore.Http;
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
        private readonly IRepositorioParamSistema _repositorioParam;
        private readonly IRepositorioPlanta _repositorioPlanta;

        public TipoPlantaController(IRepositorioTipoPlanta repositorioTipoPlanta, IRepositorioParamSistema repositorioParam, IRepositorioPlanta repositorioPlanta)
        {
            _repositorioTipoPlanta = repositorioTipoPlanta;
            _repositorioParam = repositorioParam;
            _repositorioPlanta = repositorioPlanta;
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
                return View(_repositorioTipoPlanta.Get());
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
                    ICollection<ParamSistema> parametros = new List<ParamSistema>();
                    parametros = _repositorioParam.Get();
                    int maxLargo = 0;
                    int minLargo = 0;
                    foreach (ParamSistema param in parametros)
                    {
                        if (param.Nombre.Equals("TipoDesc"))
                        {
                            maxLargo = param.ValorMax;
                            minLargo = param.ValorMin;
                        }
                    }
                    
                    if (TipoPlanta.DescValid(unTipo.TipoDesc, maxLargo, minLargo) && TipoPlanta.QuitarEspacios(unTipo.TipoNombre))
                    {
                        _repositorioTipoPlanta.Insert(unTipo);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.Mensaje = "ERROR: No cumple las validaciones";
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
                TipoPlanta unTipo = _repositorioTipoPlanta.GetByID(id);
                return View(unTipo);
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
                    ICollection<ParamSistema> parametros = new List<ParamSistema>();
                    parametros = _repositorioParam.Get();
                    int maxLargo = 0;
                    int minLargo = 0;
                    foreach (ParamSistema param in parametros)
                    {
                        if (param.Nombre.Equals("TipoDesc"))
                        {
                            maxLargo = param.ValorMax;
                            minLargo = param.ValorMin;
                        }
                    }

                    if (TipoPlanta.DescValid(unTipo.TipoDesc, maxLargo, minLargo) && TipoPlanta.QuitarEspacios(unTipo.TipoNombre))
                    {
                        try
                        {
                            _repositorioTipoPlanta.Update(unTipo);
                            return RedirectToAction(nameof(Index));
                        }
                        catch (Exception ex)
                        {

                            throw;
                        }
                    }
                    else
                    {
                        ViewBag.Mensaje = "ERROR: No cumple las validaciones";
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
                TipoPlanta unTipo = _repositorioTipoPlanta.GetByID(id);
                return View(unTipo);
            }

            return Redirect("/Login/Login");
        }

        // POST: TipoPlantaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TipoPlanta tipo)
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                try
                {
                    IList<Planta> plantas = null;
                    bool existe = false;
                    plantas = _repositorioPlanta.Get();
                    foreach (var item in plantas)
                    {
                        if (item.TipoPlanta.IdTipoPlanta == tipo.IdTipoPlanta)
                        {
                            existe = true;
                        }
                    }
                    if (existe)
                    {
                        ViewBag.Mensaje = "Tipo esta asociado a una planta existente, no se puede borrar";
                        return View("Error");
                    }
                    else
                    {
                        _repositorioTipoPlanta.Delete(tipo);
                        return RedirectToAction(nameof(Index));
                    }
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
