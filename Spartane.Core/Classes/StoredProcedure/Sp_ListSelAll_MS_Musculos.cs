using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMS_Musculos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int MS_Musculos_Folio { get; set; }
        public int MS_Musculos_Folio_Ejercicios { get; set; }
        public int? MS_Musculos_Musculo { get; set; }
        public string MS_Musculos_Musculo_Descripcion { get; set; }

    }
}
