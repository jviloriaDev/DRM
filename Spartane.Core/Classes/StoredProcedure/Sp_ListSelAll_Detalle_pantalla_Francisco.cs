using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_pantalla_Francisco : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_pantalla_Francisco_Folio { get; set; }
        public int? Detalle_pantalla_Francisco_Archivo { get; set; }
        public string Detalle_pantalla_Francisco_Archivo_Nombre { get; set; }
        public string Detalle_pantalla_Francisco_Campo { get; set; }

    }
}
