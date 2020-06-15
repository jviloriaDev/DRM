using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Suscripciones_Paciente_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Pacientes { get; set; }
        public int? Suscripcion { get; set; }
        public string Suscripcion_Nombre_del_Plan { get; set; }
        public DateTime? Fecha_de_inicio { get; set; }
        public DateTime? Fecha_fin { get; set; }
        public string Nombre_de_la_Suscripcion { get; set; }
        public int? Frecuencia_de_Pago { get; set; }
        public string Frecuencia_de_Pago_Nombre { get; set; }
        public decimal? Costo { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }

    }
}
