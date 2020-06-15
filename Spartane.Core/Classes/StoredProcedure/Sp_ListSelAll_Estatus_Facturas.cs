using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllEstatus_Facturas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Estatus_Facturas_Clave { get; set; }
        public string Estatus_Facturas_Descripcion { get; set; }

    }
}
