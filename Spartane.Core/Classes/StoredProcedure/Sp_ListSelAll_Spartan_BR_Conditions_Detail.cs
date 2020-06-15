using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_BR_Conditions_Detail : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_BR_Conditions_Detail_ConditionsDetailId { get; set; }
        public int Spartan_BR_Conditions_Detail_Business_Rule { get; set; }
        public short? Spartan_BR_Conditions_Detail_Condition_Operator { get; set; }
        public string Spartan_BR_Conditions_Detail_Condition_Operator_Description { get; set; }
        public int? Spartan_BR_Conditions_Detail_First_Operator_Type { get; set; }
        public string Spartan_BR_Conditions_Detail_First_Operator_Type_Description { get; set; }
        public string Spartan_BR_Conditions_Detail_First_Operator_Value { get; set; }
        public short? Spartan_BR_Conditions_Detail_Condition { get; set; }
        public string Spartan_BR_Conditions_Detail_Condition_Description { get; set; }
        public int? Spartan_BR_Conditions_Detail_Second_Operator_Type { get; set; }
        public string Spartan_BR_Conditions_Detail_Second_Operator_Type_Description { get; set; }
        public string Spartan_BR_Conditions_Detail_Second_Operator_Value { get; set; }

    }
}
