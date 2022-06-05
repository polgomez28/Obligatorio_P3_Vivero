using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio
{
    public abstract class Compras // La clase es abstracta porque DePlaza e Importada heredan de esta clase y no va a haber otro tipo de compra, entonces no se va a instanciar Compra
    {
        [Key]
        public int IdCompra { get; set; }
        public DateTime FechaCompra { get; set; }
        public List<Planta> ListaPlantas { get; set; }
        public double CostoTotal { get; set; }
        // agrego atributo list para listar items
        public List<ItemPlantas> Items { get; set; }
        [ForeignKey("IdItemPlanta")]
        public int IdItemPlanta { get; set; }
    }
}
