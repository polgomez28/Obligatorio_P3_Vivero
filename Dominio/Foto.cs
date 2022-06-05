using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio
{
    public class Foto
    {
        [Key]
        public int IdFoto { get; set; }
        [Required]
        public string Nombre { get; set; }
        public byte[] Imagen { get; set; }

    }
}
