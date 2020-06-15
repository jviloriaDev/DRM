using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllEnfermedades : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Enfermedades_Clave { get; set; }
        public string Enfermedades_Descripcion { get; set; }

    }
}
