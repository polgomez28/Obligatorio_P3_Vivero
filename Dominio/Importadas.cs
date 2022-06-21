using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio
{
    public class Importadas:Compra
    {
        public static int TasaImportacion { get; set; }
        public bool EsDelSur { get; set; }
        public int TasaDescuento { get; set; }
        public static string DescripcionSanitaria { get; set; }
    }
}
