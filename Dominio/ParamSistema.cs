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

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Nombre);
        }
    }
}
