using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_WorkFlow_Conditions_by_State : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow { get; set; }
        public int Spartan_WorkFlow_Conditions_by_State_Conditions_by_StateId { get; set; }
        public int? Spartan_WorkFlow_Conditions_by_State_Phase { get; set; }
        public string Spartan_WorkFlow_Conditions_by_State_Phase_Name { get; set; }
        public int? Spartan_WorkFlow_Conditions_by_State_State { get; set; }
        public string Spartan_WorkFlow_Conditions_by_State_State_Name { get; set; }
        public int? Spartan_WorkFlow_Conditions_by_State_Condition_Operator { get; set; }
        public string Spartan_WorkFlow_Conditions_by_State_Condition_Operator_Description { get; set; }
        public int? Spartan_WorkFlow_Conditions_by_State_Attribute { get; set; }
        public string Spartan_WorkFlow_Conditions_by_State_Attribute_Logical_Name { get; set; }
        public short? Spartan_WorkFlow_Conditions_by_State_Condition { get; set; }
        public string Spartan_WorkFlow_Conditions_by_State_Condition_Description { get; set; }
        public short? Spartan_WorkFlow_Conditions_by_State_Operator { get; set; }
        public string Spartan_WorkFlow_Conditions_by_State_Operator_Description { get; set; }
        public string Spartan_WorkFlow_Conditions_by_State_Operator_Value { get; set; }
        public short? Spartan_WorkFlow_Conditions_by_State_Priority { get; set; }

    }
}
