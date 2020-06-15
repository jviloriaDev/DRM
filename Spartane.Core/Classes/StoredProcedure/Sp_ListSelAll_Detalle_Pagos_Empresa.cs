using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Pagos_Empresa : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Pagos_Empresa_Folio { get; set; }
        public int Detalle_Pagos_Empresa_Folio_Empresas { get; set; }
        public int? Detalle_Pagos_Empresa_Suscripcion { get; set; }
        public string Detalle_Pagos_Empresa_Suscripcion_Nombre_del_Plan { get; set; }
        public string Detalle_Pagos_Empresa_Concepto_de_Pago { get; set; }
        public DateTime? Detalle_Pagos_Empresa_Fecha_de_Suscripcion { get; set; }
        public int? Detalle_Pagos_Empresa_Numero_de_Pago { get; set; }
        public int? Detalle_Pagos_Empresa_De_Total_de_Pagos { get; set; }
        public DateTime? Detalle_Pagos_Empresa_Fecha_Limite_de_Pago { get; set; }
        public int? Detalle_Pagos_Empresa_Recordatorio_dias { get; set; }
        public int? Detalle_Pagos_Empresa_Forma_de_Pago { get; set; }
        public string Detalle_Pagos_Empresa_Forma_de_Pago_Nombre { get; set; }
        public DateTime? Detalle_Pagos_Empresa_Fecha_de_Pago { get; set; }
        public int? Detalle_Pagos_Empresa_Estatus { get; set; }
        public string Detalle_Pagos_Empresa_Estatus_Descripcion { get; set; }

    }
}
