using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio
{
    public class FichaCuidados
    {
        [Key]
        public int IdFichaCuidados { get; set; }
        public string Riego { get; set; }
        [Required]

        public TipoIluminacion TipoIluminacion { get; set; }
        public int Temperatura { get; set; }
        [ForeignKey("IdTipoIluminacion")]
        public int IdTipoIluminacion { get; set; }
    }
}
