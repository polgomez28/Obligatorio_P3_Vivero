using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public interface IRepositorioUsuario
    {
        IList<Usuario> GetUsuarios();
    }
}
