using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Pagos_Especialistas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Pagos_Especialistas_Folio { get; set; }
        public int Detalle_Pagos_Especialistas_Folio_Especialistas { get; set; }
        public int? Detalle_Pagos_Especialistas_Plan_de_Suscripcion { get; set; }
        public string Detalle_Pagos_Especialistas_Plan_de_Suscripcion_Nombre { get; set; }
        public string Detalle_Pagos_Especialistas_Concepto_de_Pago { get; set; }
        public DateTime? Detalle_Pagos_Especialistas_Fecha_Limite_de_Pago { get; set; }
        public int? Detalle_Pagos_Especialistas_Recordatorio_dias { get; set; }
        public int? Detalle_Pagos_Especialistas_Forma_de_Pago { get; set; }
        public string Detalle_Pagos_Especialistas_Forma_de_Pago_Nombre { get; set; }
        public DateTime? Detalle_Pagos_Especialistas_Fecha_de_Pago { get; set; }
        public int? Detalle_Pagos_Especialistas_Estatus { get; set; }
        public string Detalle_Pagos_Especialistas_Estatus_Descripcion { get; set; }
        public DateTime? Detalle_Pagos_Especialistas_Fecha_de_Suscripcion { get; set; }
        public int? Detalle_Pagos_Especialistas_Numero_de_Pago { get; set; }
        public int? Detalle_Pagos_Especialistas_De_Total_de_Pagos { get; set; }

    }
}
