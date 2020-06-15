using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllAsuntos_Asistencia_Telefonica : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Asuntos_Asistencia_Telefonica_Clave { get; set; }
        public string Asuntos_Asistencia_Telefonica_Descripcion { get; set; }

    }
}
