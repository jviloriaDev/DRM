using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Identificacion_Oficial_Medicos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Identificacion_Oficial_Medicos_Folio { get; set; }
        public int Detalle_Identificacion_Oficial_Medicos_Folio_Medico { get; set; }
        public int? Detalle_Identificacion_Oficial_Medicos_Tipo_de_Identificacion_Oficial { get; set; }
        public string Detalle_Identificacion_Oficial_Medicos_Tipo_de_Identificacion_Oficial_Descripcion { get; set; }
        public int? Detalle_Identificacion_Oficial_Medicos_Documento { get; set; }
        public string Detalle_Identificacion_Oficial_Medicos_Documento_Nombre { get; set; }

    }
}
