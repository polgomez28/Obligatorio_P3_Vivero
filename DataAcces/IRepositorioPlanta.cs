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
        IList<Planta> SearchPlantas(string NombreCientifico, string TipoNombre, string Ambiente, int Altura, int Altura2);
        #endregion

        #region TipoPlanta
        IList<TipoPlanta> GetTipos();
        void UpdateTipo(TipoPlanta obj);
<<<<<<< HEAD
        bool InsertTipo(TipoPlanta unTipo);
=======
        bool InsertTipo(TipoPlanta unTipo);        
>>>>>>> 274020364cdf49c3110d98861dbe951f7e8cdb59
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
