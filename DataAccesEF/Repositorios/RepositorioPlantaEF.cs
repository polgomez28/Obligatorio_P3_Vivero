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
            IList<Planta> plantas = null;
            try
            {
                plantas = _dbContext.Plantas.ToList();
                
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception ex)
            {

                throw;
            }
            return plantas;
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
            //plantas = (from p in Planta
            //           where)
            return plantas;
        }

        public void Update(Planta obj)
        {
            throw new NotImplementedException();
        }
    }
}
