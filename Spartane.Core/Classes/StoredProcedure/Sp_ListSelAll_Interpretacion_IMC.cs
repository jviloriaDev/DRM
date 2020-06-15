using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllInterpretacion_IMC : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Interpretacion_IMC_Folio { get; set; }
        public string Interpretacion_IMC_Descripcion { get; set; }

    }
}
