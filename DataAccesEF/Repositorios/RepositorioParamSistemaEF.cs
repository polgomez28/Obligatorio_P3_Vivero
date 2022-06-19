using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccesEF
{
    public class RepositorioParamSistemaEF : IRepositorioParamSistema
    { 
        /// Ageregar inyeccion de dependencia del dbcontex que no inyecta el TipoPlantacontroller. 
        /// Aplica para cada repositorio

        ViveroContext _dbContext;


        public RepositorioParamSistemaEF(ViveroContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ParamSistema> Get()
        {
            IList<ParamSistema> param = null;
            param = _dbContext.ParamSistema.ToList();
            return param;
        }

        public ParamSistema GetByID(int id)
        {
            ParamSistema param = null;
            if (id != 0)
            {
                param = _dbContext.ParamSistema.Find(id);
            }
            return param;
        }

        public void Insert(ParamSistema obj)
        {
            throw new NotImplementedException();
        }

        public void Update(ParamSistema obj)
        {
            try
            {
                if (obj.IdParam != 0)
                {
                    _dbContext.Update<ParamSistema>(obj);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
