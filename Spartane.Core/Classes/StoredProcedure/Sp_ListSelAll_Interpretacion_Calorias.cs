using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllInterpretacion_Calorias : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Interpretacion_Calorias_Folio { get; set; }
        public string Interpretacion_Calorias_Descripcion { get; set; }

    }
}
