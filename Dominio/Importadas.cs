using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Importadas:Compras
    {
        public static double TasaImportacion { get; set; }
        public bool EsDelSur { get; set; }
        public double TasaDescuento { get; set; }
        public static string DescripcionSanitaria { get; set; }
    }
}
