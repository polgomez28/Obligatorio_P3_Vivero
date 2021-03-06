using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataAcces
{
    public interface IRepositorioPlanta_old:IRepositorio_old<Planta>
    {
        #region Planta
        //IList<Planta> GetPlantas();
        IList<Planta> SearchPlantas(string NombreCientifico, string TipoNombre, string Ambiente, int Altura, int Altura2);
        #endregion

        #region TipoPlanta
        IList<TipoPlanta> GetTipos();
        void UpdateTipo(TipoPlanta obj);

        bool InsertTipo(TipoPlanta unTipo);     

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

        #region Foto
        void InsertFoto(Foto foto);

        #endregion

        #region Listas en Planta
        Planta GetListas();

        #endregion
    }
}
