using Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.SqlClient;

namespace DataAccesEF
{
    public class RepositorioPlantaEF : IRepositorioPlanta
    {
        /// Ageregar inyeccion de dependencia del dbcontex que no inyecta el TipoPlantacontroller. 
        /// Aplica para cada repositorio

        ViveroContext _dbContext;

        public RepositorioPlantaEF(ViveroContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            Planta planta;

            try
            {
                planta = _dbContext.Plantas.Find(id);
                _dbContext.Plantas.Remove(planta);
                _dbContext.SaveChanges();
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IList<Planta> Get()
        {
            IList<Planta> result = new List<Planta>();
            try
            {
               var plantas = from p in _dbContext.Plantas
                          join t in _dbContext.TipoPlantas on
                          p.TipoPlanta.IdTipoPlanta equals t.IdTipoPlanta
                          select new
                          {
                              Id = p.IdPlanta,
                              Nombre = p.NombreCientifico,
                              Descripcion = p.Descripcion,
                              Ambiente = p.Ambiente,
                              Altura = p.Altura,
                              TipoPlanta = new { Id = t.IdTipoPlanta, Nombre = t.TipoNombre, Descripcion = t.TipoDesc}};
                foreach (var item in plantas)
                {
                    Planta planta = new Planta()
                    {
                        IdPlanta = item.Id,
                        NombreCientifico = item.Nombre,
                        Descripcion = item.Descripcion,
                        Ambiente = item.Ambiente,
                        Altura = item.Altura,
                        TipoPlanta = new TipoPlanta()
                        {
                            IdTipoPlanta = item.TipoPlanta.Id,
                            TipoNombre = item.TipoPlanta.Nombre,
                            TipoDesc = item.TipoPlanta.Descripcion
                        }
                    };
                    result.Add(planta);
                }
                return result;
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Planta GetByID(int id)
        {
            Planta planta = null;
            try
            {
                planta = _dbContext.Plantas.Find(id);

            }
            catch (Exception)
            {

                throw;
            }
            return planta;
        }

        public void Insert(Planta obj)
        {
            bool exito = false;
            try
            {
                _dbContext.Add<Planta>(obj);
                exito = _dbContext.SaveChanges() > 0;
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<Planta> SearchPlantas(string NombreCientifico, string TipoNombre, string Ambiente, int Altura, int Altura2)
        {
            IList<Planta> plantas = null;
            try
            {
                plantas = _dbContext.Plantas.Where(p => p.NombreCientifico.Contains(NombreCientifico)).ToList();
                plantas = plantas.Where(p => p.NombresVulgares.Contains(TipoNombre)).ToList();
                plantas = plantas.Where(p => p.Ambiente == Ambiente).ToList();
                plantas = plantas.Where(p => p.Altura > Altura).ToList();
                plantas = plantas.Where(p => p.Altura < Altura2).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
            
            return plantas;
        }

        public void Update(Planta obj)
        {
            try
            {
                _dbContext.Update<Planta>(obj);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
