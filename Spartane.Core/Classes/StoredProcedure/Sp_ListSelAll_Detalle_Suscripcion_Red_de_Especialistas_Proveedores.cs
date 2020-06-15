using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Suscripcion_Red_de_Especialistas_Proveedores : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Folio { get; set; }
        public int Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Folio_Proveedores { get; set; }
        public int? Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Plan_de_Suscripcion { get; set; }
        public string Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Plan_de_Suscripcion_Descripcion { get; set; }
        public DateTime? Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Fecha_inicio { get; set; }
        public DateTime? Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Fecha_fin { get; set; }
        public decimal? Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Costo { get; set; }
        public int? Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Contrato { get; set; }
        public string Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Contrato_Nombre { get; set; }
        public bool? Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Firmo_Contrato { get; set; }
        public int? Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Estatus { get; set; }
        public string Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Estatus_Descripcion { get; set; }

    }
}
