using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataAcces
{
    public interface IRepositorioUsuario
    {
        IList<Usuario> GetUsuarios();
    }
}
