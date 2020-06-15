using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllTipo_Ejercicio : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Tipo_Ejercicio_Clave { get; set; }
        public string Tipo_Ejercicio_Descripcion { get; set; }

    }
}
