using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllInterpretacion_corporal : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Interpretacion_corporal_Folio { get; set; }
        public string Interpretacion_corporal_Descripcion { get; set; }

    }
}
