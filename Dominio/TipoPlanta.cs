using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class TipoPlanta
    {
        public int IdTipoPlanta { get; set; }
        public string TipoNombre { get; set; }
        public string TipoDesc { get; set; }
        
        #region Constructores
        public TipoPlanta() { }
        public TipoPlanta(string TipoNombre, string TipoDesc)
        {
            this.TipoNombre = TipoNombre;
            this.TipoDesc = TipoDesc;
        }
        #endregion

        #region Métodos
        
        #endregion
    }
}
