using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio
{
    public class TipoPlanta
    {
        [Key]
        [Column("Id")]
        public int IdTipoPlanta { get; set; }
        [Required]
        [Column("Nombre")]
        public string TipoNombre { get; set; }
        [Required]
        [Column("Descripcion")]
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
        public static bool DescValid(string TipoDesc, int numMax, int numMin)
        {
            if (TipoDesc.Length < numMin)
            {
                return false;
            }
            else
            {
                if (TipoDesc.Length < numMax)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion
    }
}
