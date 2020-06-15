using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllCalorias : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Calorias_Clave { get; set; }
        public string Calorias_Cantidad { get; set; }

    }
}
