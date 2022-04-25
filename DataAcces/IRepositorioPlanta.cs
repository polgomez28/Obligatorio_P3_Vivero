using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataAcces
{
    public interface IRepositorioPlanta:IRepositorio<Planta>
    {
        #region Planta
        //IList<Planta> GetPlantas();

        #endregion

        #region TipoPlanta
        IEnumerable GetTipos();
        void UpdateTipo(TipoPlanta obj);
        void InsertTipo(TipoPlanta unTipo);
        TipoPlanta ExisteTipo(TipoPlanta unTipo);
        TipoPlanta GetByIdTipo(int id);
        void DeleteTipo(int idTipoPlanta);
        TipoPlanta GetByNombreTipo(string tipoNombre);

        #endregion

        #region FichaCuidados
        IEnumerable GetFichas();
        void UpdateFicha(FichaCuidados obj);
        void InsertFicha(FichaCuidados obj);
        FichaCuidados GetByIdFicha(int id);
        void DeleteFicha(int idFicha);

        #endregion

        #region TipoIluminacion
        IEnumerable GetTiposIlum();
        void DeleteTipoILum(int idTipoIlum);
        void UpdateTipoIlum(TipoIluminacion obj);
        void InsertTipoIlum(TipoIluminacion obj);
        TipoIluminacion GetByIdTipoIlum(int idTipoIlum);

#endregion

    }
}
