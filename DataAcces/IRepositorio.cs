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
        IEnumerable GetTipos();
        T GetByID(int id);
        void Insert(T obj);
        void Delete(int id);
        void Update(T obj);
        void UpdateTipo(TipoPlanta obj);
        void Save();
        void InsertTipo(TipoPlanta unTipo);
        bool ExisteTipo(TipoPlanta unTipo);
        TipoPlanta GetByIdTipo(int id);
        void DeleteTipo(int idTipoPlanta);
        TipoPlanta GetByNombreTipo(string tipoNombre);
    }
}

