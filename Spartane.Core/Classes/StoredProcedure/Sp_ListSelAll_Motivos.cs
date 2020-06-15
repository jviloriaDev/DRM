using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMotivos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Motivos_Clave { get; set; }
        public string Motivos_Descripcion { get; set; }

    }
}
