using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_BR_Condition : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_BR_Condition_ConditionId { get; set; }
        public string Spartan_BR_Condition_Description { get; set; }
        public string Spartan_BR_Condition_Implementation_Code { get; set; }

    }
}
