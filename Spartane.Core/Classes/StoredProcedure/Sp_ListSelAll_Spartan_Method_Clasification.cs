using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Method_Clasification : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_Method_Clasification_Method_Classification_Id { get; set; }
        public string Spartan_Method_Clasification_Description { get; set; }

    }
}
