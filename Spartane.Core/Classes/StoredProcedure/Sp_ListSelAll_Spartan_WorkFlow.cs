using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_WorkFlow : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_WorkFlow_WorkFlowId { get; set; }
        public string Spartan_WorkFlow_Name { get; set; }
        public string Spartan_WorkFlow_Description { get; set; }
        public string Spartan_WorkFlow_Objective { get; set; }
        public short? Spartan_WorkFlow_Status { get; set; }
        public string Spartan_WorkFlow_Status_Description { get; set; }
        public int? Spartan_WorkFlow_Object { get; set; }
        public string Spartan_WorkFlow_Object_Name { get; set; }

    }
}
