using Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesEF
{
    public class RepositorioUsuariosEF : IRepositorioUsuario
    {
        /// Ageregar inyeccion de dependencia del dbcontex que no inyecta el TipoPlantacontroller. 
        /// Aplica para cada repositorio

        ViveroContext _dbContext;

        public RepositorioUsuariosEF(ViveroContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Usuario> GetUsuarios()
        {
            throw new NotImplementedException();
        }
    }
}
