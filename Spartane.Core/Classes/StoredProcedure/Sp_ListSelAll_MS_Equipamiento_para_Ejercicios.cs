using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMS_Equipamiento_para_Ejercicios : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int MS_Equipamiento_para_Ejercicios_Folio { get; set; }
        public int MS_Equipamiento_para_Ejercicios_Folio_Ejercicios { get; set; }
        public int? MS_Equipamiento_para_Ejercicios_Equipamento { get; set; }
        public string MS_Equipamiento_para_Ejercicios_Equipamento_Descripcion { get; set; }

    }
}
