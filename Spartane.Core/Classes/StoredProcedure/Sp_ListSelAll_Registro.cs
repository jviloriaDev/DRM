using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllRegistro : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Registro_Clave { get; set; }
        public string Registro_Descripcion { get; set; }

    }
}
