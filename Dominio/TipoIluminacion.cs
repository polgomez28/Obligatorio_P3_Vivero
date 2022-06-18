using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio
{
    [Table("TipoIluminacion")]
    public class TipoIluminacion
    {
        [Key]
        [Column("Id")]
        public int IdIluminacion { get; set; }
        [Required]
        [Column("Descripcion")]
        public string DescripcionTipoIlum { get; set; }
        //[Required] da error
    }

}