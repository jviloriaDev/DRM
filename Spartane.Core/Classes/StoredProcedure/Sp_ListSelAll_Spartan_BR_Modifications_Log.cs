using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_BR_Modifications_Log : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_BR_Modifications_Log_ModificationId { get; set; }
        public int Spartan_BR_Modifications_Log_Business_Rule { get; set; }
        public DateTime? Spartan_BR_Modifications_Log_Modification_Date { get; set; }
        public string Spartan_BR_Modifications_Log_Modification_Hour { get; set; }
        public int? Spartan_BR_Modifications_Log_Modification_User { get; set; }
        public string Spartan_BR_Modifications_Log_Comments { get; set; }
        public string Spartan_BR_Modifications_Log_Implementation_Code { get; set; }

    }
}
