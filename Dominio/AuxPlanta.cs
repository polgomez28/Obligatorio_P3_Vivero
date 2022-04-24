using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class AuxPlanta
    {
        public int IdPlanta { get; set; }
        public string NombreCientifico { get; set; }
        public string Descripcion { get; set; }
        public int IdTipoPlanta { get; set; }
        public int IdFotos { get; set; }
        public int IdFichaCuidados { get; set; }
        public string NombresVulgares { get; set; }
        public string Ambiente { get; set; } // Enum o tabla?
        public string NomFotoVariable { get; set; }
        public double Altura { get; set; }
        
    }
}
