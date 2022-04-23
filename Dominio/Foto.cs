using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Foto
    {
        public int IdFoto { get; set; }
        public string Nombre { get; set; }
        public string imagen { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Nombre);
        }

        public string GenerarNombre(string nombre, string tipo, int contador)
        {
            contador++;
            nombre.Replace(" ", "_");
            nombre = nombre + "_"+ contador + "." + tipo;
            return nombre;
        }
    }
}
