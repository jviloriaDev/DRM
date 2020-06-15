using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSustancias : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Sustancias_Clave { get; set; }
        public string Sustancias_Descripcion { get; set; }

    }
}
