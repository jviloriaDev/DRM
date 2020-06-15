using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Contratos_Empresa_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Empresas { get; set; }
        public int? Suscripcion { get; set; }
        public string Suscripcion_Nombre_del_Plan { get; set; }
        public int? Tipo_de_Contrato { get; set; }
        public string Tipo_de_Contrato_Descripcion { get; set; }
        public int? Documento { get; set; }
        public DateTime? Fecha_de_Firma_de_Contrato { get; set; }

    }
}
