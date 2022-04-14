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
        
        #region Métodos
        //Verificar si contiene numeros
        public static bool NoContieneNumeros(string TipoNombre)
        {
            bool bandera = true;
            foreach (char c in TipoNombre)
            {
                if (c >= '0' && c <= '9')
                {
                    bandera = false;
                }
            }
            return bandera;
        }
        //Quitamos espacios al inicio y al final
        public static bool QuitarEspacios(string TipoNombre)
        {
            char[] charsToTrim = { ' ' };
            string result = TipoNombre.Trim(charsToTrim);
            return NoContieneNumeros(result);
        }
        
        #endregion
    }
}
