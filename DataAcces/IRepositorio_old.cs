

using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataAcces
{
    public interface IRepositorio_old<T>
    {
        IList<T> Get();              
        T GetByID(int id);
        void Insert(T obj);
        void Delete(int id);
        void Update(T obj);                   
    }
}

