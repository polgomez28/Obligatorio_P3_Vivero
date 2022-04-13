using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class ParamSistema
    {
        public int IdParam { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int ValorMin { get; set; }
        public int ValorMax { get; set; }
        
        public ParamSistema() { }
        public ParamSistema(string Nombre, string Descripcion, int ValorMin, int ValorMax)
        {
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
            this.ValorMin = ValorMin;
            this.ValorMax = ValorMax;
        }
    }
}
