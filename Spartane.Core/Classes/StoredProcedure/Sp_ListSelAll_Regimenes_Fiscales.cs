using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllRegimenes_Fiscales : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Regimenes_Fiscales_Clave { get; set; }
        public string Regimenes_Fiscales_Descripcion { get; set; }

    }
}
