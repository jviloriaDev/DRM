using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_WorkFlow_Condition_Operator : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_WorkFlow_Condition_Operator_Condition_OperatorId { get; set; }
        public string Spartan_WorkFlow_Condition_Operator_Description { get; set; }

    }
}
