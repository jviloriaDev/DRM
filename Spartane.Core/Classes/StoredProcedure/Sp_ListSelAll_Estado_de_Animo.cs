using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllEstado_de_Animo : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Estado_de_Animo_Clave { get; set; }
        public string Estado_de_Animo_Descripcion { get; set; }

    }
}
