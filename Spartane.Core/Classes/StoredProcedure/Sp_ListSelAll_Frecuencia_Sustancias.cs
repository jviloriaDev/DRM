using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllFrecuencia_Sustancias : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Frecuencia_Sustancias_Clave { get; set; }
        public string Frecuencia_Sustancias_Descripcion { get; set; }

    }
}
