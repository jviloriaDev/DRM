using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_BR_Action_Configuration_Detail_Complete : BaseEntity
    {
        public int ActionConfigurationId { get; set; }
        public int Action { get; set; }
        public string Parameter_Name { get; set; }
        public int? Parameter_Type { get; set; }
        public string Parameter_Type_Description { get; set; }

    }
}
