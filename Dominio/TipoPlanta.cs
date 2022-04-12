using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class TipoPlanta
    {
        public int IdTipo { get; }
        public string Name { get; set; }
        public string DescripcionTipo { get; set; }
        
        #region Constructores
        public TipoPlanta() { }
        public TipoPlanta(string Name, string DescripcionTipo)
        {
            this.Name = Name;
            this.DescripcionTipo = DescripcionTipo;
        }
        #endregion

        #region Métodos
        
        #endregion
    }
}
