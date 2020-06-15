using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_BR_Action_Param_Type : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_BR_Action_Param_Type_ParameterTypeId { get; set; }
        public string Spartan_BR_Action_Param_Type_Description { get; set; }
        public int? Spartan_BR_Action_Param_Type_Presentation_Control_Type { get; set; }
        public string Spartan_BR_Action_Param_Type_Presentation_Control_Type_Description { get; set; }
        public string Spartan_BR_Action_Param_Type_Query_for_Fill_Condition { get; set; }
        public string Spartan_BR_Action_Param_Type_Code_for_Fill_Condition { get; set; }
        public string Spartan_BR_Action_Param_Type_Implementation_Code { get; set; }

    }
}
