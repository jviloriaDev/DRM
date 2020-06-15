using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllPreferencias_Preparacion : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Preferencias_Preparacion_Clave { get; set; }
        public string Preferencias_Preparacion_Descripcion { get; set; }

    }
}
