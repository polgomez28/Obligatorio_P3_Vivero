using Dominio;
using Dominio.DtoCompra;
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
        private readonly IRepositorioCompras _repoCompras;
        private readonly IRepositorioParamSistema _repoParam;

        public ComprasController(IRepositorioDePlaza repositorioDePlaza, IRepositorioPlanta repositorioPlanta, IRepositorioCompras repositorioCompras, IRepositorioParamSistema repositorioParamSistema)
        {
            _repoDePlaza = repositorioDePlaza;
            _repoPlanta = repositorioPlanta;
            _repoCompras = repositorioCompras;
            _repoParam = repositorioParamSistema;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Add(DePlaza dePlaza)
        {
            if (dePlaza != null)
            {
                IList<ParamSistema> paramSistemas = new List<ParamSistema>();
                int IVA = 0;
                paramSistemas = _repoParam.Get();
                foreach (var item in paramSistemas)
                {
                    if (item.Nombre == "TasaIVA")
                    {
                        IVA = item.ValorMax;
                    }
                }
                _repoDePlaza.Insert(IVA, dePlaza);
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                Uri uri = new Uri(Request.Scheme + "://" + Request.Host + "/api/" + controllerName + "/" + dePlaza.Id);

                return Created(uri.AbsoluteUri, dePlaza);

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DePlaza))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            return Ok(_repoCompras.GetTipo(id));
        }

    }
}
