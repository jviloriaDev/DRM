using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllCantidad_fraccion_platillos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Cantidad_fraccion_platillos_Folio { get; set; }
        public string Cantidad_fraccion_platillos_Cantidad { get; set; }

    }
}
