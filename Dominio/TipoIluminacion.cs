﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio
{
    public class TipoIluminacion
    {
        public int IdIluminacion { get; set; }
        public string DescripcionTipoIlum { get; set; }
        //[Required] da error
    }

}