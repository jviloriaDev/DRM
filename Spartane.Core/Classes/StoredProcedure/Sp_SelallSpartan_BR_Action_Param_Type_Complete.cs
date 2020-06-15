using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_BR_Action_Param_Type_Complete : BaseEntity
    {
        public int ParameterTypeId { get; set; }
        public string Description { get; set; }
        public int? Presentation_Control_Type { get; set; }
        public string Presentation_Control_Type_Description { get; set; }
        public string Query_for_Fill_Condition { get; set; }
        public string Code_for_Fill_Condition { get; set; }
        public string Implementation_Code { get; set; }

    }
}
