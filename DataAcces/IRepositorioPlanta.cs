using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataAcces
{
    public interface IRepositorioPlanta:IRepositorio<Planta>
    {
        IEnumerable GetTipos();
        void UpdateTipo(TipoPlanta obj);
        void InsertTipo(TipoPlanta unTipo);
        TipoPlanta ExisteTipo(TipoPlanta unTipo);
        TipoPlanta GetByIdTipo(int id);
        void DeleteTipo(int idTipoPlanta);
        TipoPlanta GetByNombreTipo(string tipoNombre);

    }
}
