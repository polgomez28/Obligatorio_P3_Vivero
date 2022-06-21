using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio
{
    public class ItemCompra
    {
        [ForeignKey("Planta")]
        public int IdPlanta { get; set; }
        [ForeignKey("Compra")]
        public int IdCompra { get; set; }
        public Planta Planta { get; set; }
        public Compra Compra { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
