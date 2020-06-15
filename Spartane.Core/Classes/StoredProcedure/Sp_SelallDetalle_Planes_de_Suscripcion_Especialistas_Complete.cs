using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Planes_de_Suscripcion_Especialistas_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Especialistas { get; set; }
        public int? Plan_de_Suscripcion { get; set; }
        public string Plan_de_Suscripcion_Nombre { get; set; }
        public DateTime? Fecha_de_inicio { get; set; }
        public DateTime? Fecha_fin { get; set; }
        public int? Frecuencia_de_Pago { get; set; }
        public string Frecuencia_de_Pago_Nombre { get; set; }
        public decimal? Costo { get; set; }
        public int? Contrato { get; set; }
        public bool? Firmo_Contrato { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }

    }
}
