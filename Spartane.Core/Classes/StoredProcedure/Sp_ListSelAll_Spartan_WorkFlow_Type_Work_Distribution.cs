using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_WorkFlow_Type_Work_Distribution : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_WorkFlow_Type_Work_Distribution_Type_of_Work_DistributionId { get; set; }
        public string Spartan_WorkFlow_Type_Work_Distribution_Description { get; set; }

    }
}
