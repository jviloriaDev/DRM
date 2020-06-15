using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Settings : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public string Spartan_Settings_Clave { get; set; }
        public string Spartan_Settings_Valor { get; set; }

    }
}
