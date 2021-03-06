using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public interface IRepositorioPlanta:IRepositorio<Planta>
    {
        #region Planta
        //IList<Planta> GetPlantas();
        IList<Planta> SearchPlantas(string NombreCientifico, string TipoNombre, string Ambiente, int Altura, int Altura2);
        IList<Planta> SearchForType(Planta planta);
        IList<Planta> SearchForName(Planta planta);
        IList<Planta> SearchAmbiente(Planta planta);
        IList<Planta> SearchHeight(Planta planta);
        IList<Planta> SearchGreaterHeight(Planta planta);
        #endregion

        #region TipoPlanta
        /*
        IList<TipoPlanta> GetTipos();
        void UpdateTipo(TipoPlanta obj);

        bool InsertTipo(TipoPlanta unTipo);     

        TipoPlanta GetByIdTipo(int id);
        void DeleteTipo(int idTipoPlanta);
        TipoPlanta GetByNombreTipo(string tipoNombre);
        */
        #endregion

        #region FichaCuidados

        IList GetFichas();
        void UpdateFicha(FichaCuidados obj);
        void InsertFicha(FichaCuidados obj);
        FichaCuidados GetByIdFicha(int id);
        void DeleteFicha(int idFicha);

        #endregion

        #region TipoIluminacion
        /*
        IEnumerable GetTiposIlum();
        void DeleteTipoILum(int idTipoIlum);
        void UpdateTipoIlum(TipoIluminacion obj);
        void InsertTipoIlum(TipoIluminacion obj);
        TipoIluminacion GetByIdTipoIlum(int idTipoIlum);
        */
        #endregion

        #region Foto
        /*
        void InsertFoto(Foto foto);

        #endregion

        #region Listas en Planta
        Planta GetListas();
        */
        #endregion
    }
}
