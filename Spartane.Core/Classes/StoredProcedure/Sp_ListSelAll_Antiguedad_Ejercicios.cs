using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllAntiguedad_Ejercicios : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Antiguedad_Ejercicios_Clave { get; set; }
        public string Antiguedad_Ejercicios_Descripcion { get; set; }

    }
}
