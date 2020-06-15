using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllPreferencias_Grasas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Preferencias_Grasas_Clave { get; set; }
        public string Preferencias_Grasas_Descripcion { get; set; }

    }
}
