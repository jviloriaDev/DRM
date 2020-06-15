using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllPlanes_de_Suscripcion_Especialistas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Planes_de_Suscripcion_Especialistas_Folio { get; set; }
        public string Planes_de_Suscripcion_Especialistas_Nombre { get; set; }
        public int? Planes_de_Suscripcion_Especialistas_Costo { get; set; }
        public int? Planes_de_Suscripcion_Especialistas_Estatus { get; set; }
        public string Planes_de_Suscripcion_Especialistas_Estatus_Descripcion { get; set; }

    }
}
