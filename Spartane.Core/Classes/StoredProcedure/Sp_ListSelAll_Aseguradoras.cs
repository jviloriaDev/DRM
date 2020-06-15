using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllAseguradoras : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Aseguradoras_Folio { get; set; }
        public string Aseguradoras_Nombre { get; set; }

    }
}
