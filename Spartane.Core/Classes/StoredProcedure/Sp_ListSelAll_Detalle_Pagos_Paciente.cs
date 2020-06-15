using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Pagos_Paciente : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Pagos_Paciente_Folio { get; set; }
        public int Detalle_Pagos_Paciente_Folio_Pacientes { get; set; }
        public int? Detalle_Pagos_Paciente_Suscripcion { get; set; }
        public string Detalle_Pagos_Paciente_Suscripcion_Nombre_del_Plan { get; set; }
        public string Detalle_Pagos_Paciente_Concepto_de_Pago { get; set; }
        public DateTime? Detalle_Pagos_Paciente_Fecha_de_Suscripcion { get; set; }
        public int? Detalle_Pagos_Paciente_Numero_de_Pago { get; set; }
        public int? Detalle_Pagos_Paciente_De_Total_de_Pagos { get; set; }
        public DateTime? Detalle_Pagos_Paciente_Fecha_Limite_de_Pago { get; set; }
        public int? Detalle_Pagos_Paciente_Recordatorio_dias { get; set; }
        public int? Detalle_Pagos_Paciente_Forma_de_Pago { get; set; }
        public string Detalle_Pagos_Paciente_Forma_de_Pago_Nombre { get; set; }
        public DateTime? Detalle_Pagos_Paciente_Fecha_de_Pago { get; set; }
        public int? Detalle_Pagos_Paciente_Estatus { get; set; }
        public string Detalle_Pagos_Paciente_Estatus_Descripcion { get; set; }

    }
}
