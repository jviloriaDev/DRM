using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllCalificacion : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Calificacion_Clave { get; set; }
        public string Calificacion_Descripcion { get; set; }

    }
}
