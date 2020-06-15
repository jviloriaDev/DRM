using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_BR_Action_Configuration_Detail : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_BR_Action_Configuration_Detail_ActionConfigurationId { get; set; }
        public int Spartan_BR_Action_Configuration_Detail_Action { get; set; }
        public string Spartan_BR_Action_Configuration_Detail_Parameter_Name { get; set; }
        public int? Spartan_BR_Action_Configuration_Detail_Parameter_Type { get; set; }
        public string Spartan_BR_Action_Configuration_Detail_Parameter_Type_Description { get; set; }

    }
}
