using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllParentesco : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Parentesco_Clave { get; set; }
        public string Parentesco_Descripcion { get; set; }

    }
}
