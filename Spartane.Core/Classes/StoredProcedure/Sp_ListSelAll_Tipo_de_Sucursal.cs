using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllTipo_de_Sucursal : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Tipo_de_Sucursal_Clave { get; set; }
        public string Tipo_de_Sucursal_Descripcion { get; set; }

    }
}
