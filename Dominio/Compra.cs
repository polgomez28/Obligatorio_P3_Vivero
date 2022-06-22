using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio
{
    public abstract class Compra // La clase es abstracta porque DePlaza e Importada heredan de esta clase y no va a haber otro tipo de compra, entonces no se va a instanciar Compra
    {
        public int Id { get; set; }
        public DateTime FechaCompra { get; set; }
        //public List<Planta> ListaPlantas { get; set; }
        public decimal CostoTotal { get; set; }
        // agrego atributo list para listar items
        
        public List<ItemCompra> Items { get; set; }


        public decimal CalcularCostoImpuesto(int Tasa, decimal monto)
        {
            if (Tasa > 0 && monto > 0)
            {
                return (Tasa * monto) / 100;
            }
            else
            {
                return 0;
            }
        }
        
    }
}
