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

        ViveroContext _dbContext;
        
        public RepositorioTipoPlantaEF(ViveroContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(TipoPlanta tipo)
        {
            try
            {
                _dbContext.Update<TipoPlanta>(tipo);
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
        
        public TipoPlanta GetByID(int id)
        {
            TipoPlanta tipo = null;
            try
            {
                tipo = _dbContext.TipoPlantas.Find(id);
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
        
        public bool Delete(TipoPlanta unTipo)
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
        /// <summary>
        /// Agregamos un Tipo de planta
        /// </summary>
        /// <param name="unTipo"></param>
        /// <returns></returns>
        public void Insert(TipoPlanta obj)
        {
            try
            {
                _dbContext.Add<TipoPlanta>(obj);
                _dbContext.SaveChanges();
            }
            catch (SqlException ex)
            {
                ex.Message.ToString();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
