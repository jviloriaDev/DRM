using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_WorkFlow_Type_Flow_Control : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_WorkFlow_Type_Flow_Control_Type_Flow_ControlId { get; set; }
        public string Spartan_WorkFlow_Type_Flow_Control_Description { get; set; }

    }
}
