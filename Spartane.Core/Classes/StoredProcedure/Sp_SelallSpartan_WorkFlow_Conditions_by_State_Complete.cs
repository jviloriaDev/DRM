using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_WorkFlow_Conditions_by_State_Complete : BaseEntity
    {
        public int Spartan_WorkFlow { get; set; }
        public int Conditions_by_StateId { get; set; }
        public int? Phase { get; set; }
        public string Phase_Name { get; set; }
        public int? State { get; set; }
        public string State_Name { get; set; }
        public int? Condition_Operator { get; set; }
        public string Condition_Operator_Description { get; set; }
        public int? Attribute { get; set; }
        public string Attribute_Logical_Name { get; set; }
        public short? Condition { get; set; }
        public string Condition_Description { get; set; }
        public short? Operator { get; set; }
        public string Operator_Description { get; set; }
        public string Operator_Value { get; set; }
        public short? Priority { get; set; }

    }
}
