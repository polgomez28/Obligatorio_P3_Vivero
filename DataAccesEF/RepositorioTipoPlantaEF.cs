using Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.SqlClient;

namespace DataAccesEF
{
    public class RepositorioTipoPlantaEF
    {
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
                using (VivieroContext dbContext = new VivieroContext())
                {
                    dbContext.Add<TipoPlanta>(unTipo);
                    exito = dbContext.SaveChanges() > 0;
                    return exito;
                }
                
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

        public IList<TipoPlanta> FindAll()
        {
            IList<TipoPlanta> tipos = null;
            try
            {
                using (VivieroContext dbContext = new VivieroContext())
                {
                    tipos = dbContext.TipoPlantas.ToList();
                }
                return tipos;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
