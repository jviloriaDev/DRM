using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_WorkFlow_Condition : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_WorkFlow_Condition_ConditionId { get; set; }
        public string Spartan_WorkFlow_Condition_Description { get; set; }

    }
}
