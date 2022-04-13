using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class ParamSistema
    {
        public int IdParam { get; set; }
        public int TipoDescMin { get; set; }
        public int TipoDescMax { get; set; }
        public int PlantaDescMin { get; set; }
        public int PlantaDescMax { get; set; }
        public int TasaIVA { get; set; }
        public int TasaImpuesto { get; set; }
        public int TasaArancelaria { get; set; }
        
        public ParamSistema() { }
        public ParamSistema(int TipoDescMin, int TipoDescMax, int PlantaDescMin, int PlantaDescMax, int TasaIVA, int TasaImpuesto, int TasaArancelaria)
        {
            this.TipoDescMin = TipoDescMin;
            this.TipoDescMax = TipoDescMax;
            this.PlantaDescMin = PlantaDescMin;
            this.PlantaDescMax = PlantaDescMax;
            this.TasaIVA = TasaIVA;
            this.TasaImpuesto = TasaImpuesto;
            this.TasaArancelaria = TasaArancelaria;
        }
    }
}
