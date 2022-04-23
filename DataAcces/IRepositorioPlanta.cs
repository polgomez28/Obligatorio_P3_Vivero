using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataAcces
{
    public interface IRepositorioPlanta:IRepositorio<Planta>
    {
        // Tipo planta
        IEnumerable GetTipos();
        void UpdateTipo(TipoPlanta obj);
        void InsertTipo(TipoPlanta unTipo);
        TipoPlanta ExisteTipo(TipoPlanta unTipo);
        TipoPlanta GetByIdTipo(int id);
        void DeleteTipo(int idTipoPlanta);
        TipoPlanta GetByNombreTipo(string tipoNombre);

        // Ficha cuidados
        IEnumerable GetFichas();
        void UpdateFicha(FichaCuidados obj);
        void InsertFicha(FichaCuidados obj);
        FichaCuidados GetByIdFicha(int id);
        void DeleteFicha(int idFicha);

        // Tipo iluminacion
        IEnumerable GetTiposIlum();
        void DeleteTipoILum(int idTipoIlum);
        void UpdateTipoIlum(TipoIluminacion obj);
        void InsertTipoIlum(TipoIluminacion obj);
        TipoIluminacion GetByIdTipoIlum(int idTipoIlum);        

    }
}
