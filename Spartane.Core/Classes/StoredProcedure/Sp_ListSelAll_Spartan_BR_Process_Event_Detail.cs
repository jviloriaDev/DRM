using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_BR_Process_Event_Detail : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_BR_Process_Event_Detail_ProcessEventDetailId { get; set; }
        public int Spartan_BR_Process_Event_Detail_Business_Rule { get; set; }
        public short? Spartan_BR_Process_Event_Detail_Process_Event { get; set; }
        public string Spartan_BR_Process_Event_Detail_Process_Event_Description { get; set; }

    }
}
