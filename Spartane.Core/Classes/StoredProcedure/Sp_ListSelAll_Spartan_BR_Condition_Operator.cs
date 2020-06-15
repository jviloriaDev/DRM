using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_BR_Condition_Operator : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_BR_Condition_Operator_ConditionOperatorId { get; set; }
        public string Spartan_BR_Condition_Operator_Description { get; set; }
        public string Spartan_BR_Condition_Operator_Implementation_Code { get; set; }

    }
}
