using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSexo : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Sexo_Clave { get; set; }
        public string Sexo_Descripcion { get; set; }

    }
}
