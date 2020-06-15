using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllTipos_de_Actividades : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Tipos_de_Actividades_Folio { get; set; }
        public string Tipos_de_Actividades_Descripcion { get; set; }

    }
}
