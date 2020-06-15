using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllFrecuencia_Ejercicio : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Frecuencia_Ejercicio_Clave { get; set; }
        public string Frecuencia_Ejercicio_Descripcion { get; set; }

    }
}
