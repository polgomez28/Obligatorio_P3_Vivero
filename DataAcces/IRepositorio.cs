using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataAcces
{
    public interface IRepositorio<T>
    {
        IEnumerable Get();        
        //IEnumerable GetFichas();
        T GetByID(int id);
        void Insert(T obj);
        void Delete(int id);
        void Update(T obj);
        void Save();
        
        /*void UpdateFicha(FichaCuidados obj);
        void InsertFicha(FichaCuidados obj);
        FichaCuidados GetByIdFicha(int id);
        void DeleteTipoILum(int idFicha);
        void UpdateTipoIlum(FichaCuidados obj);
        void InsertTipoIlum(FichaCuidados obj);
        FichaCuidados GetById(int id);
        void DeleteFicha(int idFicha);*/


    }
}

