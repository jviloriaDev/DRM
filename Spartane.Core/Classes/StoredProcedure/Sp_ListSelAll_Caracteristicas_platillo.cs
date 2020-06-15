using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllCaracteristicas_platillo : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Caracteristicas_platillo_Folio { get; set; }
        public string Caracteristicas_platillo_Caracteristicas { get; set; }

    }
}
