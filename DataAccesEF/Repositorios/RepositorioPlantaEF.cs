using Dominio;
using System;
using System.Collections.Generic;
using System.Text;

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
            throw new NotImplementedException();
        }

        public IList<Planta> Get()
        {
            throw new NotImplementedException();
        }

        public Planta GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Planta obj)
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
    }
}
