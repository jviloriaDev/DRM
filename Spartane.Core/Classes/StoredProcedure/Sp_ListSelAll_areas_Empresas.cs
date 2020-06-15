using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllareas_Empresas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int areas_Empresas_Clave { get; set; }
        public string areas_Empresas_Nombre { get; set; }

    }
}
