using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio
{
    public class ItemPlantas
    {
        [Key]
        public int IdItemPlanta { get; set; }
        public Planta PlantaComprada { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
    }
}
