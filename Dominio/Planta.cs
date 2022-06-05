using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio
{
    public class Planta
    {
        [Key]
        public int IdPlanta { get; set; }
        public string NombreCientifico { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public TipoPlanta TipoPlanta { get; set; }
        public List<Foto> ListaFotos { get; set; }
        public FichaCuidados FichaCuidados { get; set; }
        public string NombresVulgares { get; set; }
        [Required]
        public string Ambiente { get; set; }
        public int Altura { get; set; }


        public List<TipoPlanta> ListaTipoPlantas { get; set; }

        public List<FichaCuidados> ListaFichas { get; set; }

        // Validaciones

        // --- Validar Nombre Científico

        // ------ No contiene números
        public static bool NoContieneNumeros(string nombreCien)
        {
            bool valido = true;
            foreach (char c in nombreCien)
            {
                if (c >= '0' && c <= '9')
                {
                    valido = false;
                }
            }
            return valido;
        }              
        
        // ------ Quitar espacios inicio y final
        public static string QuitarEspacios(string nombreCien)
        {
            char[] charsToTrim = { ' ' };
            string nombreSinEspacios = nombreCien.Trim(charsToTrim);
            return nombreSinEspacios;
        }

        // ------ Validar descripcion

        public static bool LargoValido(string desc, int max, int min)
        {
            if(desc.Length < max && desc.Length > min)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        // --- Validar Nombres Vulgares
        public static bool NombresValidos(string nombres)
        {
            bool valido = true;
            if (nombres.EndsWith(",") || nombres.StartsWith(","))
            {
                valido = false;
            }
            if (nombres.Contains(",,"))
            {
                valido = false;
            }

            return valido;
        }
    }
}
