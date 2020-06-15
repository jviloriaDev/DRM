using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Suscripcion_Red_de_Especialistas_Proveedores_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Proveedores { get; set; }
        public int? Plan_de_Suscripcion { get; set; }
        public string Plan_de_Suscripcion_Descripcion { get; set; }
        public DateTime? Fecha_inicio { get; set; }
        public DateTime? Fecha_fin { get; set; }
        public decimal? Costo { get; set; }
        public int? Contrato { get; set; }
        public bool? Firmo_Contrato { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }

    }
}
