using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Planta
    {
        public int IdPlanta { get; set; }
        public string NombreCientifico { get; set; }
        public string Descripcion { get; set; }
        public TipoPlanta TipoPlanta { get; set; }
        public List<Foto> FotosPlanta { get; set; }
        public FichaCuidados FichaCuidados { get; set; }
        public List<NombresVulgares> NombresVulgares { get; set; }
        public string Ambiente { get; set; } // Enum o tabla?
        public double Altura { get; set; }

        // Agregar métodos de validación, tal vez hacer una clase que maneje eso

    }
}
