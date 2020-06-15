using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllPreferencias_Entrecomidas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Preferencias_Entrecomidas_Clave { get; set; }
        public string Preferencias_Entrecomidas_Descripcion { get; set; }

    }
}
