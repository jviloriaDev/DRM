using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllTipo_Modificacion_Alimentos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Tipo_Modificacion_Alimentos_Clave { get; set; }
        public string Tipo_Modificacion_Alimentos_Descripcion { get; set; }

    }
}
