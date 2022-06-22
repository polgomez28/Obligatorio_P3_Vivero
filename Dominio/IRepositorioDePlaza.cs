using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public interface IRepositorioDePlaza : IRepositorio<DePlaza>
    {
        void Insert(int IVA, DePlaza obj);
    }
}
