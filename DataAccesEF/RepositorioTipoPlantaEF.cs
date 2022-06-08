using Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.SqlClient;
using DataAcces;
using System.Collections;

namespace DataAccesEF
{
    public class RepositorioTipoPlantaEF : IRepositorioPlanta
    {
        /// Ageregar inyeccion de dependencia del dbcontex que no inyecta el TipoPlantacontroller. 
        /// Aplica para cada repositorio

        VivieroContext _dbContext = new VivieroContext();

        public RepositorioTipoPlantaEF(VivieroContext dbContext) 
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

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteFicha(int idFicha)
        {
            throw new NotImplementedException();
        }

        public void DeleteTipo(int idTipoPlanta)
        {
            throw new NotImplementedException();
        }

        public void DeleteTipoILum(int idTipoIlum)
        {
            throw new NotImplementedException();
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

        public IList<Planta> Get()
        {
            throw new NotImplementedException();
        }

        public Planta GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public FichaCuidados GetByIdFicha(int id)
        {
            throw new NotImplementedException();
        }

        public TipoPlanta GetByIdTipo(int id)
        {
            throw new NotImplementedException();
        }

        public TipoIluminacion GetByIdTipoIlum(int idTipoIlum)
        {
            throw new NotImplementedException();
        }

        public TipoPlanta GetByNombreTipo(string tipoNombre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable GetFichas()
        {
            throw new NotImplementedException();
        }

        public Planta GetListas()
        {
            throw new NotImplementedException();
        }

        public IList<TipoPlanta> GetTipos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable GetTiposIlum()
        {
            throw new NotImplementedException();
        }

        public void Insert(Planta obj)
        {
            throw new NotImplementedException();
        }

        public void InsertFicha(FichaCuidados obj)
        {
            throw new NotImplementedException();
        }

        public void InsertFoto(Foto foto)
        {
            throw new NotImplementedException();
        }

        public bool InsertTipo(TipoPlanta unTipo)
        {
            throw new NotImplementedException();
        }

        public void InsertTipoIlum(TipoIluminacion obj)
        {
            throw new NotImplementedException();
        }

        public IList<Planta> SearchPlantas(string NombreCientifico, string TipoNombre, string Ambiente, int Altura, int Altura2)
        {
            throw new NotImplementedException();
        }

        public void Update(Planta obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateFicha(FichaCuidados obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateTipo(TipoPlanta obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateTipoIlum(TipoIluminacion obj)
        {
            throw new NotImplementedException();
        }
    }
}
