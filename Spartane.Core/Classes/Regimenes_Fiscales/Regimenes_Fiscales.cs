﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Regimenes_Fiscales
{
    /// <summary>
    /// Regimenes_Fiscales table
    /// </summary>
    public class Regimenes_Fiscales: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

