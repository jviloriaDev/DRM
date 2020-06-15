using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllParentescos_Empleados : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Parentescos_Empleados_Folio { get; set; }
        public string Parentescos_Empleados_Descripcion { get; set; }

    }
}
