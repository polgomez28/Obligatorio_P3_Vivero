using Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.SqlClient;
using System.Collections;

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

        public void DeleteFicha(int idFicha)
        {
            throw new NotImplementedException();
        }

        public IList<Planta> Get()
        {
            IList<Planta> result = new List<Planta>();
            try
            {
               var plantas = from p in _dbContext.Plantas
                          join t in _dbContext.TipoPlantas on p.TipoPlanta.IdTipoPlanta equals t.IdTipoPlanta
                          join f in _dbContext.FichaCuidados on p.FichaCuidados.IdFichaCuidados equals f.IdFichaCuidados
                          select new
                          {
                              Id = p.IdPlanta,
                              Nombre = p.NombreCientifico,
                              Descripcion = p.Descripcion,
                              Ambiente = p.Ambiente,
                              Altura = p.Altura,
                              Vulgares = p.NombresVulgares,
                              TipoPlanta = new { Id = t.IdTipoPlanta, Nombre = t.TipoNombre, Descripcion = t.TipoDesc},
                              FichaCuidados = new { Id = f.IdFichaCuidados, Riego = f.Riego, Temperatura = f.Temperatura }
                          };
                foreach (var item in plantas)
                {
                    Planta planta = new Planta()
                    {
                        IdPlanta = item.Id,
                        NombreCientifico = item.Nombre,
                        Descripcion = item.Descripcion,
                        Ambiente = item.Ambiente,
                        Altura = item.Altura,
                        NombresVulgares = item.Vulgares,
                        TipoPlanta = new TipoPlanta()
                        {
                            IdTipoPlanta = item.TipoPlanta.Id,
                            TipoNombre = item.TipoPlanta.Nombre,
                            TipoDesc = item.TipoPlanta.Descripcion
                        },
                        FichaCuidados = new FichaCuidados()
                        {
                            IdFichaCuidados = item.FichaCuidados.Id,
                            Riego = item.FichaCuidados.Riego,
                            Temperatura = item.FichaCuidados.Temperatura
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
            IList<Planta> plantas = new List<Planta>();
            Planta planta = null;
            
            try
            {
                plantas = Get();
                foreach (var item in plantas)
                {
                    if (item.IdPlanta == id)
                    {
                        planta = item;
                    }
                }
                return planta;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public FichaCuidados GetByIdFicha(int id)
        {
            throw new NotImplementedException();
        }

        public IList GetFichas()
        {
            IList<FichaCuidados> fichaCuidados = null;
            fichaCuidados = _dbContext.FichaCuidados.ToList();
            return (IList)fichaCuidados;
        }

        public void Insert(Planta obj)
        {
            try
            {
                _dbContext.Add<Planta>(obj);
                obj.TipoPlanta = _dbContext.TipoPlantas.Find(obj.TipoPlanta.IdTipoPlanta);
                _dbContext.Entry(obj.TipoPlanta).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                obj.FichaCuidados = _dbContext.FichaCuidados.Find(obj.FichaCuidados.IdFichaCuidados);
                _dbContext.Entry(obj.FichaCuidados).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                _dbContext.SaveChanges();
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

        public void InsertFicha(FichaCuidados obj)
        {
            throw new NotImplementedException();
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
                obj.TipoPlanta = _dbContext.TipoPlantas.Find(obj.TipoPlanta.IdTipoPlanta);
                _dbContext.Entry(obj.TipoPlanta).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public void UpdateFicha(FichaCuidados obj)
        {
            throw new NotImplementedException();
        }
    }
}
