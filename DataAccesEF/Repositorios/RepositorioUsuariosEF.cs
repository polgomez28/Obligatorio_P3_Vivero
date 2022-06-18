using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
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
            IList<Usuario> usuarios = new List<Usuario>();
            try
            {
                usuarios = _dbContext.Usuarios.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return usuarios;
        }
    }
}
