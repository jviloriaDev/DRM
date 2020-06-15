using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllEstado_Civil : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Estado_Civil_Clave { get; set; }
        public string Estado_Civil_Descripcion { get; set; }

    }
}
