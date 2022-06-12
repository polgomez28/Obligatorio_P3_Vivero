using Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.SqlClient;
using System.Collections;

namespace DataAccesEF
{
    public class RepositorioTipoPlantaEF : IRepositorioTipoPlanta
    {
        /// Ageregar inyeccion de dependencia del dbcontex que no inyecta el TipoPlantacontroller. 
        /// Aplica para cada repositorio

        ViveroContext _dbContext = new ViveroContext();

        public RepositorioTipoPlantaEF(ViveroContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Agregamos un Tipo de planta
        /// </summary>
        /// <param name="unTipo"></param>
        /// <returns>True si se graba y false en caso contrario</returns>
        public bool Add(TipoPlanta unTipo)
        {
            bool exito = false;
            try
            {

                _dbContext.Add<TipoPlanta>(unTipo);
                exito = _dbContext.SaveChanges() > 0;
                return exito;


            }
            catch (SqlException ex)
            {
                ex.Message.ToString();
                return exito;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public bool Update(TipoPlanta tipo)
        {
            bool exito = false;
            try
            {
                _dbContext.Update<TipoPlanta>(tipo);
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
            return exito;
            
        }
        public IList<TipoPlanta> GetTipoPlantas()
        {
            IList<TipoPlanta> tipos = null;
            try
            {
                
                tipos = _dbContext.TipoPlantas.ToList();

            }
            catch (Exception ex)
            {
                throw;
            }
            return tipos;

        }
        public TipoPlanta GetByID(int id)
        {
            TipoPlanta tipo = null;
            try
            {
                int Id = (int)id;
                tipo = _dbContext.TipoPlantas.Find(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
            return tipo;
        }

        public TipoPlanta GetByNombreTipo(string TipoNombre)
        {
            TipoPlanta tipo = null;
            try
            {
                tipo = _dbContext.TipoPlantas.Find(TipoNombre);
            }
            catch (Exception ex)
            {

                throw;
            }
            return tipo;
        }
        
        public bool Remove(TipoPlanta unTipo)
        {
            bool exito = false;
            try
            {
                _dbContext.TipoPlantas.Remove(unTipo);
                exito = _dbContext.SaveChanges() > 0;
            }
            catch (SqlException ex)
            {

                throw;
            }
            return exito;
        }

        public IList<TipoPlanta> Get()
        {
            throw new NotImplementedException();
        }

        public void Insert(TipoPlanta obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        void Dominio.IRepositorio<TipoPlanta>.Update(TipoPlanta obj)
        {
            throw new NotImplementedException();
        }
    }
}
