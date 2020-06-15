using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllIdentificaciones_Oficiales : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Identificaciones_Oficiales_Clave { get; set; }
        public string Identificaciones_Oficiales_Descripcion { get; set; }

    }
}
