﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio
{
    public class Importadas:Compras
    {
        [Key]
        public int IdImportadas { get; }
        public static int TasaImportacion { get; set; }
        public bool EsDelSur { get; set; }
        public int TasaDescuento { get; set; }
        public static string DescripcionSanitaria { get; set; }
        [ForeignKey("IdPlanta")]
        public int IdPlanta { get; set; }
        public Planta Planta { get; set; }
    }
}
