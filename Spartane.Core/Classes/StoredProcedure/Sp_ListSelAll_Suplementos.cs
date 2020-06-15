using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSuplementos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Suplementos_Clave { get; set; }
        public string Suplementos_Descripcion { get; set; }

    }
}
