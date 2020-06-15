using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllEstatus_Reservaciones_Actividad : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Estatus_Reservaciones_Actividad_Folio { get; set; }
        public string Estatus_Reservaciones_Actividad_Descripcion { get; set; }

    }
}
