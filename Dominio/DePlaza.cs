using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio
{
    public class DePlaza:Compra
    {
        
        public decimal TasaIVA { get; set; }
        public double CostoFlete { get; set; }
    }
}
