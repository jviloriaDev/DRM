using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Suscripciones_Paciente : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Suscripciones_Paciente_Folio { get; set; }
        public int Detalle_Suscripciones_Paciente_Folio_Pacientes { get; set; }
        public int? Detalle_Suscripciones_Paciente_Suscripcion { get; set; }
        public string Detalle_Suscripciones_Paciente_Suscripcion_Nombre_del_Plan { get; set; }
        public DateTime? Detalle_Suscripciones_Paciente_Fecha_de_inicio { get; set; }
        public DateTime? Detalle_Suscripciones_Paciente_Fecha_fin { get; set; }
        public string Detalle_Suscripciones_Paciente_Nombre_de_la_Suscripcion { get; set; }
        public int? Detalle_Suscripciones_Paciente_Frecuencia_de_Pago { get; set; }
        public string Detalle_Suscripciones_Paciente_Frecuencia_de_Pago_Nombre { get; set; }
        public decimal? Detalle_Suscripciones_Paciente_Costo { get; set; }
        public int? Detalle_Suscripciones_Paciente_Estatus { get; set; }
        public string Detalle_Suscripciones_Paciente_Estatus_Descripcion { get; set; }

    }
}
