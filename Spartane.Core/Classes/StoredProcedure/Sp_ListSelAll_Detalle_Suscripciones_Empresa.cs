using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Suscripciones_Empresa : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Suscripciones_Empresa_Folio { get; set; }
        public int Detalle_Suscripciones_Empresa_Folio_Empresas { get; set; }
        public int? Detalle_Suscripciones_Empresa_Cantidad_de_Beneficiarios { get; set; }
        public int? Detalle_Suscripciones_Empresa_Suscripcion { get; set; }
        public string Detalle_Suscripciones_Empresa_Suscripcion_Nombre_del_Plan { get; set; }
        public DateTime? Detalle_Suscripciones_Empresa_Fecha_de_inicio { get; set; }
        public DateTime? Detalle_Suscripciones_Empresa_Fecha_Fin { get; set; }
        public string Detalle_Suscripciones_Empresa_Nombre_de_la_Suscripcion { get; set; }
        public int? Detalle_Suscripciones_Empresa_Frecuencia_de_Pago { get; set; }
        public string Detalle_Suscripciones_Empresa_Frecuencia_de_Pago_Nombre { get; set; }
        public decimal? Detalle_Suscripciones_Empresa_Costo { get; set; }
        public int? Detalle_Suscripciones_Empresa_Estatus { get; set; }
        public string Detalle_Suscripciones_Empresa_Estatus_Descripcion { get; set; }

    }
}
