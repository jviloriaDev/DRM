using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Preferencia_Bebidas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Preferencia_Bebidas_Folio { get; set; }
        public int Detalle_Preferencia_Bebidas_Folio_Pacientes { get; set; }
        public int? Detalle_Preferencia_Bebidas_Bebida { get; set; }
        public string Detalle_Preferencia_Bebidas_Bebida_Descripcion { get; set; }
        public int? Detalle_Preferencia_Bebidas_Cantidad { get; set; }
        public string Detalle_Preferencia_Bebidas_Cantidad_Descripcion { get; set; }

    }
}
