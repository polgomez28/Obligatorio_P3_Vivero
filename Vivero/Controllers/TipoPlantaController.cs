using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using DataAcces;

namespace Vivero.Controllers
{
    public class TipoPlantaController : Controller
    {
        IRepositorioPlanta repositorio = new RepositorioPlanta(new Connection());
        IRepositorio<ParamSistema> repositorioParam = new RepositorioParamSistema(new Connection());
        // GET: TipoPlantaController
        public ActionResult Index()
        {
            if (!(HttpContext.Session.GetString("_Name") is null))
            {
                return View(repositorio.GetTipos());
            }
            return Redirect("/Login/Login");
        }

        // GET: TipoPlantaController/Details/5
        public ActionResult Details(int id)
        {
            if (!(HttpContext.Session.GetString("_Name") is null))
            {
                return View();
            }

            return Redirect("/Login/Login");
        }

        // GET: TipoPlantaController/Create
        public ActionResult Create()
        {
            if (!(HttpContext.Session.GetString("_Name") is null))
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
            if (!(HttpContext.Session.GetString("_Name") is null))
            {
                try
                {
                    ICollection<ParamSistema> resultado = new List<ParamSistema>();
                    resultado = (ICollection<ParamSistema>)repositorioParam.Get();
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
                                TipoPlanta uT = null;
                                uT = repositorio.ExisteTipo(unTipo);
                                if (uT==null)
                                {
                                    repositorio.InsertTipo(unTipo);
                                    return View("SuccessAlta");
                                }
                                else
                                {
                                    return View("ErrorAlta");
                                }
                                
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
            if (!(HttpContext.Session.GetString("_Name") is null))
            {
                TipoPlanta unTipo = repositorio.GetByIdTipo(id);
                return View(unTipo);
            }

            return Redirect("/Login/Login");
        }

        // POST: TipoPlantaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoPlanta unTipo)
        {
            if (!(HttpContext.Session.GetString("_Name") is null))
            {
                try
                {
                    ICollection<ParamSistema> resultado = new List<ParamSistema>();
                    resultado = (ICollection<ParamSistema>)repositorioParam.Get();
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
                                repositorio.UpdateTipo(unTipo);
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
            if (!(HttpContext.Session.GetString("_Name") is null))
            {
                TipoPlanta unTipo = repositorio.GetByIdTipo(id);
                return View(unTipo);
            }

            return Redirect("/Login/Login");
        }

        // POST: TipoPlantaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTipo(int IdTipoPlanta)
        {
            if (!(HttpContext.Session.GetString("_Name") is null))
            {
                try
                {
                    repositorio.DeleteTipo(IdTipoPlanta);
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
            if (!(HttpContext.Session.GetString("_Name") is null))
            {
                return View();
            }

            return Redirect("/Login/Login");
        }
        [HttpPost]
        public ActionResult Search(string TipoNombre)
        {
            if (!(HttpContext.Session.GetString("_Name") is null))
            {
                try

                {
                    TipoPlanta unTipo = repositorio.GetByNombreTipo(TipoNombre);
                    if (unTipo == null)
                    {
                        return View("ErrorAlta");
                    }
                    else
                    {
                        return View("ViewSearch", unTipo);
                    }
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
