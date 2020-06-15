using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_WorkFlow_State : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_WorkFlow_State_Spartan_WorkFlow { get; set; }
        public int Spartan_WorkFlow_State_StateId { get; set; }
        public int? Spartan_WorkFlow_State_Phase { get; set; }
        public string Spartan_WorkFlow_State_Phase_Name { get; set; }
        public int? Spartan_WorkFlow_State_Attribute { get; set; }
        public string Spartan_WorkFlow_State_Attribute_Logical_Name { get; set; }
        public int? Spartan_WorkFlow_State_State_Code { get; set; }
        public string Spartan_WorkFlow_State_Name { get; set; }
        public int? Spartan_WorkFlow_State_Value { get; set; }
        public string Spartan_WorkFlow_State_Text { get; set; }

    }
}
