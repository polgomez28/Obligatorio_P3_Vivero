using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace Vivero.Controllers
{
    public class PlantaController : Controller
    {
        private readonly IRepositorioPlanta _repositorioPlanta;
        private readonly IRepositorioTipoPlanta _repositorioTipo;
        private readonly IRepositorioParamSistema _repositorioParam;

        public PlantaController(IRepositorioPlanta repositorioPlanta, IRepositorioTipoPlanta repositorioTipoPlanta, IRepositorioParamSistema repositorioParam)
        {
            _repositorioPlanta = repositorioPlanta;
            _repositorioTipo = repositorioTipoPlanta;
            _repositorioParam = repositorioParam;
        }

        /* CONEXION VIEJA
        IRepositorioPlanta repositorioPlanta = new RepositorioPlanta(new Connection());
        IRepositorio<ParamSistema> repositorioParam = new RepositorioParamSistema(new Connection());
        */

        // Para trabajar con el upload de la foto
        //private IWebHostEnvironment _environment;
        //public PlantaController(IWebHostEnvironment environment)
        //{
        //    _environment = environment;
        //}
        // GET: HomeController1
        public ActionResult Index()
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                List<Planta> plantas = (List<Planta>)_repositorioPlanta.Get();
                return View(plantas);
            }

            return Redirect("/Login/Login");
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                Planta unaPlanta = _repositorioPlanta.GetByID(id);
                return View(unaPlanta);
            }

            return Redirect("/Login/Login");
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                return View("CreateFoto");
            }

            return Redirect("/Login/Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Planta unaPlanta, IFormFile imagen)
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                return View();
            }

            return Redirect("/Login/Login");
        }

        // GET Create Planta
        public ActionResult CreatePlanta()
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {                                
                //return View(_repositorioPlanta.GetListas());
            }

            return Redirect("/Login/Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePlanta(Planta unaPlanta, int IdFichaCuidados, int IdTipoPlanta)
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                try
                {
                    TipoPlanta unT = new TipoPlanta();
                    FichaCuidados unF = new FichaCuidados();
                    ICollection<ParamSistema> parametros = new List<ParamSistema>();
                    //parametros = (ICollection<ParamSistema>)repositorioParam.Get();
                    int maxLargo = 0;
                    int minLargo = 0;
                    foreach (ParamSistema param in parametros)
                    {
                        if (param.Nombre.Equals("PlantaDesc"))
                        {
                            maxLargo = param.ValorMax;
                            minLargo = param.ValorMin;
                        }                        
                    }
                    unaPlanta.NombreCientifico = Planta.QuitarEspacios(unaPlanta.NombreCientifico);
                    unaPlanta.Descripcion = Planta.QuitarEspacios(unaPlanta.Descripcion);
                    unT.IdTipoPlanta = IdTipoPlanta;
                    unF.IdFichaCuidados = IdFichaCuidados;
                    unaPlanta.TipoPlanta = unT;
                    unaPlanta.FichaCuidados = unF;
                    if (Planta.NoContieneNumeros(unaPlanta.NombreCientifico) && Planta.LargoValido(unaPlanta.Descripcion, maxLargo, minLargo) && Planta.NombresValidos(unaPlanta.NombresVulgares))
                    {
                        try
                        {
                            _repositorioPlanta.Insert(unaPlanta);
                            return View("SuccessAlta");
                        }
                        catch (Exception e)
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



        // POST: HomeController1/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Planta unaPlanta, IFormFile imagen)
        //{
        //    return View();
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFoto(Foto foto, IFormFile imagen)
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                try
                {
                    if (ModelState.IsValid && !(imagen is null))
                    {
                        foto.Imagen = ConvertImageToByteArray(imagen);
                        //_repositorioPlanta.InsertFoto(foto);
                    }
                    else
                    {
                        return View();
                    }
                }
                catch
                {
                    return View();
                }
            }

            return Redirect("/Login/Login");
        }
        private byte[] ConvertImageToByteArray(IFormFile imagen)
        {
            byte[] imagenByte;
            using (var ms = new MemoryStream())
            {
                imagen.CopyTo(ms);
                imagenByte = ms.ToArray();
            }
            return imagenByte;
        }


        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                ViewBag.FichaCuidados = _repositorioPlanta.GetFichas();
                ViewBag.TipoPlanta = _repositorioTipo.Get();
                Planta unaPlanta = _repositorioPlanta.GetByID(id);
                return View(unaPlanta);
            }

            return Redirect("/Login/Login");
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,[Bind("IdPlanta,NombreCientifico,Descripcion,TipoPlanta,FichaCuidados,NombresVulgares,Ambiente,Altura")] Planta unaPlanta)
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                try
                {
                    ICollection<ParamSistema> parametros = new List<ParamSistema>();
                    parametros = _repositorioParam.Get();
                    int maxLargo = 0;
                    int minLargo = 0;
                    foreach(ParamSistema param in parametros)
                    {
                        if (param.Nombre.Equals("PlantaDesc"))
                        {
                            maxLargo = param.ValorMax;
                            minLargo = param.ValorMin;
                        }
                    }
                    Planta aux = null;
                    aux = _repositorioPlanta.GetByID(id);
                        if (aux.NombreCientifico == unaPlanta.NombreCientifico && aux.NombresVulgares == unaPlanta.NombresVulgares && aux.Descripcion == unaPlanta.Descripcion)
                        {
                            _repositorioPlanta.Update(unaPlanta);
                            return RedirectToAction(nameof(Index));
                        }
                        else
                        {
                            unaPlanta.NombreCientifico = Planta.QuitarEspacios(unaPlanta.NombreCientifico);
                            unaPlanta.Descripcion = Planta.QuitarEspacios(unaPlanta.Descripcion);
                            if (Planta.NoContieneNumeros(unaPlanta.NombreCientifico) && Planta.LargoValido(unaPlanta.Descripcion, maxLargo, minLargo) && Planta.NombresValidos(unaPlanta.NombresVulgares))
                            {
                                try
                                {
                                    _repositorioPlanta.Update(unaPlanta);
                                    return RedirectToAction(nameof(Index));
                                }
                                catch (Exception e)
                                {
                                    return View("ErrorAlta");
                                }

                            }
                            else
                            {
                                return View("ErrorAlta");
                            }
                        }
                                        
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return Redirect("/Login/Login");
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                Planta unaPlanta = _repositorioPlanta.GetByID(id);
                return View(unaPlanta);
            }

            return Redirect("/Login/Login");
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePlanta(int idPlanta)
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                try
                {
                    _repositorioPlanta.Delete(idPlanta);
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
            return View();
        }

        [HttpPost]
        public ActionResult Search(string NombreCientifico, string TipoNombre, string Ambiente, int Altura, int Altura2)
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Logeado")))
            {
                try

                {
                    if (NombreCientifico == null)
                    {
                        NombreCientifico = "";
                    }
                    if (TipoNombre == null)
                    {
                        TipoNombre = "";
                    }
                    if (Ambiente == null)
                    {
                        Ambiente = "";
                    }
                    IList<Planta> listPlantas = _repositorioPlanta.SearchPlantas(NombreCientifico, TipoNombre, Ambiente, Altura, Altura2);
                    return View("VisualizarSearch", listPlantas);
                    
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
