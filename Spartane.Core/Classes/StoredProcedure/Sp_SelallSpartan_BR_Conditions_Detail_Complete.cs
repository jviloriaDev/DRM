using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_BR_Conditions_Detail_Complete : BaseEntity
    {
        public int ConditionsDetailId { get; set; }
        public int Business_Rule { get; set; }
        public short? Condition_Operator { get; set; }
        public string Condition_Operator_Description { get; set; }
        public int? First_Operator_Type { get; set; }
        public string First_Operator_Type_Description { get; set; }
        public string First_Operator_Value { get; set; }
        public short? Condition { get; set; }
        public string Condition_Description { get; set; }
        public int? Second_Operator_Type { get; set; }
        public string Second_Operator_Type_Description { get; set; }
        public string Second_Operator_Value { get; set; }

    }
}
