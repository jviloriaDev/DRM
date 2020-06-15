using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Contratos_Empresa : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Contratos_Empresa_Folio { get; set; }
        public int Detalle_Contratos_Empresa_Folio_Empresas { get; set; }
        public int? Detalle_Contratos_Empresa_Suscripcion { get; set; }
        public string Detalle_Contratos_Empresa_Suscripcion_Nombre_del_Plan { get; set; }
        public int? Detalle_Contratos_Empresa_Tipo_de_Contrato { get; set; }
        public string Detalle_Contratos_Empresa_Tipo_de_Contrato_Descripcion { get; set; }
        public int? Detalle_Contratos_Empresa_Documento { get; set; }
        public string Detalle_Contratos_Empresa_Documento_Nombre { get; set; }
        public DateTime? Detalle_Contratos_Empresa_Fecha_de_Firma_de_Contrato { get; set; }

    }
}
