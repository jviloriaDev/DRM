using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Terapia_Hormonal : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Terapia_Hormonal_Folio { get; set; }
        public int Detalle_Terapia_Hormonal_Folio_Pacientes { get; set; }
        public string Detalle_Terapia_Hormonal_Nombre { get; set; }
        public string Detalle_Terapia_Hormonal_Dosis { get; set; }

    }
}
