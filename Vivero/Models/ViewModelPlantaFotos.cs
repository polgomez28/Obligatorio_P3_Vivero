using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace Vivero.Models
{
    public class ViewModelPlantaFotos
    {
        public Planta unaPlanta { get; set; }
        public List<Foto> fotos { get; set; }
    }
}
