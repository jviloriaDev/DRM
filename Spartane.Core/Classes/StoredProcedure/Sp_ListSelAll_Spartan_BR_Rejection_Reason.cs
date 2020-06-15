using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_BR_Rejection_Reason : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_BR_Rejection_Reason_Key_Rejection_Reason { get; set; }
        public string Spartan_BR_Rejection_Reason_Description { get; set; }

    }
}
