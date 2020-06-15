using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllEstatus_Actividades_Evento : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Estatus_Actividades_Evento_Folio { get; set; }
        public string Estatus_Actividades_Evento_Descripcion { get; set; }

    }
}
