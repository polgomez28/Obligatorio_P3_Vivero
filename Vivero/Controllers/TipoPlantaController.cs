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
        IRepositorio<Planta> repositorio = new RepositorioPlanta(new Connection());
        IRepositorio<ParamSistema> repositorioParam = new RepositorioParamSistema(new Connection());
        // GET: TipoPlantaController
        public ActionResult Index()
        {
            return View(repositorio.GetTipos());
        }

        // GET: TipoPlantaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoPlantaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPlantaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoPlanta unTipo)
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
                                repositorio.InsertTipo(unTipo);
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
            catch
            {
                return View("ErrorAlta");
            }
        }

        // GET: TipoPlantaController/Edit/5
        public ActionResult Edit(int id)
        {
            TipoPlanta unTipo = repositorio.GetByIdTipo(id);
            return View(unTipo);
        }

        // POST: TipoPlantaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoPlanta unTipo)
        {
            repositorio.UpdateTipo(unTipo);
            return View("SuccessAlta");
        }

        // GET: TipoPlantaController/Delete/5
        public ActionResult Delete(int id)
        {
            TipoPlanta unTipo = repositorio.GetByIdTipo(id);
            return View(unTipo);
        }

        // POST: TipoPlantaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTipo(int IdTipoPlanta)
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
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string TipoNombre)
        {
            TipoPlanta unTipo = repositorio.GetByNombreTipo(TipoNombre);
            return View("ViewSearch", unTipo);
        }
    }
}
