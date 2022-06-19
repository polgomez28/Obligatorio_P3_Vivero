using Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public interface IRepositorioTipoPlanta : IRepositorio<TipoPlanta>
    {
        bool Delete(TipoPlanta unTipo);
    }
}
