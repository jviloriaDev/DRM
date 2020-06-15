using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllPadecimientos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Padecimientos_Clave { get; set; }
        public string Padecimientos_Descripcion { get; set; }

    }
}
