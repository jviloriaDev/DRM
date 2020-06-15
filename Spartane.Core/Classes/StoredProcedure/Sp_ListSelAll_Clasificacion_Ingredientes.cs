using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllClasificacion_Ingredientes : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Clasificacion_Ingredientes_Clave { get; set; }
        public string Clasificacion_Ingredientes_Descripcion { get; set; }

    }
}
