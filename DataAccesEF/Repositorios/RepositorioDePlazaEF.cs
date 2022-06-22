using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dominio;
using Dominio.DtoCompra;

namespace DataAccesEF
{
    public class RepositorioDePlazaEF : IRepositorioDePlaza
    {
        ViveroContext _dbContext;

        public RepositorioDePlazaEF(ViveroContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<DePlaza> Get()
        {
            throw new NotImplementedException();
            //try
            //{

            //    IList<DePlaza> result = null;
            //    var dePlaza = from c in _dbContext.DePlazas
            //                  join i in _dbContext.ItemCompras on c.Id equals i.IdCompra
            //                  join p in _dbContext.Plantas on i.IdPlanta equals p.IdPlanta
            //                  where p.TipoPlanta.IdTipoPlanta == 2
            //                  select new
            //                  {
            //                      Id = c.Id,
            //                      Fecha = c.FechaCompra,
            //                      CostoTotal = c.CostoTotal,
            //                      CostoFlete = c.CostoFlete,
            //                      ItemCompra = new { IdPlanta = i.IdPlanta, IdCompra = i.IdCompra, Planta = new { Nombre = i.Planta.NombreCientifico, Descripcion = i.Planta.Descripcion }, Cantidad = i.Cantidad, PrecioUni = i.PrecioUnitario }
            //                  };
            //    result = (IList<DePlaza>)dePlaza.ToList();
            //    return result;
            //}
            //catch (SqlException ex)
            //{

            //    throw;
            //}

        }

        public DePlaza GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IList<DePlaza> GetTipo(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(int IVA, DePlaza obj)
        {

            try
            {
                
                decimal sumaCosto = 0;
                decimal impuesto = 0;
                if (obj != null)
                {
                    foreach (var item in obj.Items)
                    {
                        sumaCosto = item.Cantidad * item.PrecioUnitario;
                    }
                    if (sumaCosto > 0)
                    {
                        impuesto = obj.CalcularCostoImpuesto(IVA, sumaCosto);
                    }
                    obj.CostoTotal = sumaCosto + impuesto;
                    obj.TasaIVA = impuesto;
                    _dbContext.Add<DePlaza>(obj);
                    _dbContext.SaveChanges();
                }
                
            }
            catch (SqlException ex)
            {

                throw;
            }
            
        }

        public void Insert(DePlaza obj)
        {
            throw new NotImplementedException();
        }

        public void Update(DePlaza obj)
        {
            throw new NotImplementedException();
        }

        IList<DtoCompra> IRepositorio<DePlaza>.GetTipo(int id)
        {
            throw new NotImplementedException();
        }
    }
}
