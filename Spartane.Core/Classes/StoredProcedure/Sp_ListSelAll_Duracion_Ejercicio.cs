using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDuracion_Ejercicio : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Duracion_Ejercicio_Clave { get; set; }
        public string Duracion_Ejercicio_Descripcion { get; set; }

    }
}
