using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly IRepositorioDePlaza _repoDePlaza;
        private readonly IRepositorioPlanta _repoPlanta;
        

        public ComprasController(IRepositorioDePlaza repositorioDePlaza, IRepositorioPlanta repositorioPlanta)
        {
            _repoDePlaza = repositorioDePlaza;
            _repoPlanta = repositorioPlanta;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Add(DePlaza dePlaza)
        {
            if (dePlaza != null)
            {
                _repoDePlaza.Insert(dePlaza);
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                Uri uri = new Uri(Request.Scheme + "://" + Request.Host + "/api/" + controllerName + "/" + dePlaza.Id);

                return Created(uri.AbsoluteUri, dePlaza);

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Planta))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            return Ok(_repoPlanta.Get());
        }

    }
}
