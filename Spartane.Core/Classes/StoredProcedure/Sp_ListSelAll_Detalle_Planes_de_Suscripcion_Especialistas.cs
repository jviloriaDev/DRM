using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Planes_de_Suscripcion_Especialistas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Planes_de_Suscripcion_Especialistas_Folio { get; set; }
        public int Detalle_Planes_de_Suscripcion_Especialistas_Folio_Especialistas { get; set; }
        public int? Detalle_Planes_de_Suscripcion_Especialistas_Plan_de_Suscripcion { get; set; }
        public string Detalle_Planes_de_Suscripcion_Especialistas_Plan_de_Suscripcion_Nombre { get; set; }
        public DateTime? Detalle_Planes_de_Suscripcion_Especialistas_Fecha_de_inicio { get; set; }
        public DateTime? Detalle_Planes_de_Suscripcion_Especialistas_Fecha_fin { get; set; }
        public int? Detalle_Planes_de_Suscripcion_Especialistas_Frecuencia_de_Pago { get; set; }
        public string Detalle_Planes_de_Suscripcion_Especialistas_Frecuencia_de_Pago_Nombre { get; set; }
        public decimal? Detalle_Planes_de_Suscripcion_Especialistas_Costo { get; set; }
        public int? Detalle_Planes_de_Suscripcion_Especialistas_Contrato { get; set; }
        public string Detalle_Planes_de_Suscripcion_Especialistas_Contrato_Nombre { get; set; }
        public bool? Detalle_Planes_de_Suscripcion_Especialistas_Firmo_Contrato { get; set; }
        public int? Detalle_Planes_de_Suscripcion_Especialistas_Estatus { get; set; }
        public string Detalle_Planes_de_Suscripcion_Especialistas_Estatus_Descripcion { get; set; }

    }
}
