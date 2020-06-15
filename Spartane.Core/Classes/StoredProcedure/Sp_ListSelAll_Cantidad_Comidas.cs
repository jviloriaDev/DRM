using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllCantidad_Comidas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Cantidad_Comidas_Clave { get; set; }
        public string Cantidad_Comidas_Descripcion { get; set; }

    }
}
