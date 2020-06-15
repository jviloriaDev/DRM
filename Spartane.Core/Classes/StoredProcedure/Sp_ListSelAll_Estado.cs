using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllEstado : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Estado_Clave { get; set; }
        public string Estado_Nombre_del_Estado { get; set; }
        public int? Estado_Folio_Pais { get; set; }
        public string Estado_Folio_Pais_Nombre_del_Pais { get; set; }

    }
}
