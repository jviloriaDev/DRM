﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Frecuencia_de_pago_Empresas
{
    /// <summary>
    /// Frecuencia_de_pago_Empresas table
    /// </summary>
    public class Frecuencia_de_pago_Empresas: BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }


    }
}

