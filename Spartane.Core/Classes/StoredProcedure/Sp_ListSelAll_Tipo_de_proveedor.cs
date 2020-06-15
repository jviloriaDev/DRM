using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllTipo_de_proveedor : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Tipo_de_proveedor_Clave { get; set; }
        public string Tipo_de_proveedor_Descripcion { get; set; }

    }
}
