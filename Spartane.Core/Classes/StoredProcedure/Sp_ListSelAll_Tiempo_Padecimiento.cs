﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllTiempo_Padecimiento : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Tiempo_Padecimiento_Clave { get; set; }
        public string Tiempo_Padecimiento_Descripcion { get; set; }

    }
}
