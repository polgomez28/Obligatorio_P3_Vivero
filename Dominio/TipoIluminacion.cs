using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio
{
    public class TipoIluminacion
    {
        [Key]
        public int IdIluminacion { get; set; }
        [Required]
        public string DescripcionTipoIlum { get; set; }
        //[Required] da error
    }

}