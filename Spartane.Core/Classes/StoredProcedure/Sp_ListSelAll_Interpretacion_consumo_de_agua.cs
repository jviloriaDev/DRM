using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllInterpretacion_consumo_de_agua : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Interpretacion_consumo_de_agua_Folio { get; set; }
        public string Interpretacion_consumo_de_agua_Descripcion { get; set; }

    }
}
