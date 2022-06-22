using Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccesEF;
using System.Linq;
using Newtonsoft.Json;
using Dominio.DtoCompra;
namespace DataAccesEF
{
    public class RepositorioComprasEF : IRepositorioCompras
    {
        ViveroContext _dbContext;

        public RepositorioComprasEF(ViveroContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<DtoCompra> GetTipo(int id)
        {
            try
            {
                IList<DtoCompra> dtoCompras = new List<DtoCompra>();
                ItemCompra itemaux = new ItemCompra();
                var compras = from c in _dbContext.Compras
                              join i in _dbContext.ItemCompras on c.Id equals i.IdCompra
                              join p in _dbContext.Plantas on i.IdPlanta equals p.IdPlanta
                              select new
                              {
                                  Id = c.Id,
                                  Fecha = c.FechaCompra,
                                  NombrePlanta = p.NombreCientifico,
                                  Cantidad = i.Cantidad,
                                  PrecioUni = i.PrecioUnitario,
                                  Tipo = p.TipoPlanta.IdTipoPlanta
                              };
                foreach (var item in compras)
                {
                    if (item.Tipo == id)
                    {
                        DtoCompra dtoCompra = new DtoCompra()
                        {
                            IdCompra = item.Id,
                            Fecha = item.Fecha,
                            Nombre = item.NombrePlanta,
                            Cantidad = item.Cantidad,
                            PrecioUnitario = item.PrecioUni
                        };
                        dtoCompras.Add(dtoCompra);
                    }
                }
                return dtoCompras;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<Compra> Get()
        {
            throw new NotImplementedException();
        }

        public Compra GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Compra obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Compra obj)
        {
            throw new NotImplementedException();
        }

    }
}
