using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Especialistas_Pacientes : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Especialistas_Pacientes_Folio { get; set; }
        public int Detalle_Especialistas_Pacientes_Folio_Pacientes { get; set; }
        public int? Detalle_Especialistas_Pacientes_Especialista { get; set; }
        public string Detalle_Especialistas_Pacientes_Especialista_Name { get; set; }
        public int? Detalle_Especialistas_Pacientes_Especialidad { get; set; }
        public string Detalle_Especialistas_Pacientes_Especialidad_Especialidad { get; set; }
        public DateTime? Detalle_Especialistas_Pacientes_Fecha_inicio { get; set; }
        public DateTime? Detalle_Especialistas_Pacientes_Fecha_fin { get; set; }
        public int? Detalle_Especialistas_Pacientes_Cantidad_consultas { get; set; }
        public bool? Detalle_Especialistas_Pacientes_Principal { get; set; }
        public int? Detalle_Especialistas_Pacientes_Estatus { get; set; }
        public string Detalle_Especialistas_Pacientes_Estatus_Descripcion { get; set; }

    }
}
