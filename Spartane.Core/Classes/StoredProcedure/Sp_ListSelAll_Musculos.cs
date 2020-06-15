using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMusculos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Musculos_Folio { get; set; }
        public string Musculos_Descripcion { get; set; }

    }
}
