﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio
{
    public class DePlaza:Compras
    {
        [Key]
        public int IdPlaza { get; }
        public static double TasaIVA { get; set; }
        public double CostoFlete { get; set; }

    }
}
