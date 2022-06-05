using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio
{
    public class ParamSistema
    {
        [Key]
        public int IdParam { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int ValorMin { get; set; }
        public int ValorMax { get; set; }
    }
}
