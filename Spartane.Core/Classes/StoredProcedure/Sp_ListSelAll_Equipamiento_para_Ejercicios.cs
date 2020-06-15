using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllEquipamiento_para_Ejercicios : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Equipamiento_para_Ejercicios_Folio { get; set; }
        public string Equipamiento_para_Ejercicios_Descripcion { get; set; }

    }
}
