using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using DataAcces;

namespace Vivero.Controllers
{
    public class PlantaController : Controller
    {
        IRepositorioPlanta repositorioPlanta = new RepositorioPlanta(new Connection());
        IRepositorio<ParamSistema> repositorioParam = new RepositorioParamSistema(new Connection());
        // Para trabajar con el upload de la foto
        private IWebHostEnvironment _environment;
        public PlantaController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        // GET: HomeController1
        public ActionResult Index()
        {
            if (!(HttpContext.Session.GetString("_Name") is null))
            {
                List<Planta> plantas = (List<Planta>)repositorioPlanta.Get();
                return View(plantas);
            }

            return Redirect("/Login/Login");
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            if (!(HttpContext.Session.GetString("_Name") is null))
            {
                return View();
            }

            return Redirect("/Login/Login");
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            if (!(HttpContext.Session.GetString("_Name") is null))
            {
                return View("CreateFoto");
            }

            return Redirect("/Login/Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Planta unaPlanta, IFormFile imagen)
        {
            if (!(HttpContext.Session.GetString("_Name") is null))
            {
                return View();
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
        public ActionResult CreateFoto(Foto unaFoto, IFormFile imagen)
        {
            if (!(HttpContext.Session.GetString("_Name") is null))
            {
                try
                {
                    if (unaFoto == null || imagen == null || !ModelState.IsValid)

                        return View();
                    // ruta física donde está ubicada wwroot en el servidor

                    if (GuardarImagen(imagen, unaFoto))
                    {
                        return View("VisualizarFoto", unaFoto);
                    }
                    return View(unaFoto);
                }
                catch
                {
                    return View();
                }
            }

            return Redirect("/Login/Login");
        }
        private bool GuardarImagen(IFormFile imagen, Foto unaFoto)
        {
            if (imagen == null || unaFoto == null)
                return false;

            // subir la imagen
            string rutaFisicaWwwRoot = _environment.WebRootPath;
            //ruta donde se guardan las fotos de las plantas
            string nombreImagen = imagen.FileName;
            string rutaFisicaFoto = Path.Combine
                                (rutaFisicaWwwRoot, "imagenes", "fotos", nombreImagen);
            //FileStream permite manejar archivos
            try
            {
                //el método using libera los recursos del objeto FileStream al finalizar
                using (FileStream f = new FileStream(rutaFisicaFoto, FileMode.Create))
                {
                    //si fueran archivos grandes o si fueran varios, deberíamos usar la versión
                    //asincrónica de CopyTo, aquí no es necesario.
                    //sería: await imagen.CopyToAsync (f);
                    imagen.CopyTo(f);
                }
                unaFoto.imagen = nombreImagen;
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            if (!(HttpContext.Session.GetString("_Name") is null))
            {
                return View();
            }

            return Redirect("/Login/Login");
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            if (!(HttpContext.Session.GetString("_Name") is null))
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

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            if (!(HttpContext.Session.GetString("_Name") is null))
            {
                return View();
            }

            return Redirect("/Login/Login");
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (!(HttpContext.Session.GetString("_Name") is null))
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
