using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllPeriodo_del_dia : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Periodo_del_dia_Clave { get; set; }
        public string Periodo_del_dia_Descripcion { get; set; }

    }
}
