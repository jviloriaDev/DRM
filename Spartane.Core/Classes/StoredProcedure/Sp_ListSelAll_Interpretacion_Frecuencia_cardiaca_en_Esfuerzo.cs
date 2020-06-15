using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllInterpretacion_Frecuencia_cardiaca_en_Esfuerzo : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Interpretacion_Frecuencia_cardiaca_en_Esfuerzo_Folio { get; set; }
        public string Interpretacion_Frecuencia_cardiaca_en_Esfuerzo_Descripcion { get; set; }

    }
}
