using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class ItemCompra
    {
        public int IdPlanta { get; set; }
        public int IdCompra { get; set; }
        public Planta Planta { get; set; }
        public Compras Compras { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
