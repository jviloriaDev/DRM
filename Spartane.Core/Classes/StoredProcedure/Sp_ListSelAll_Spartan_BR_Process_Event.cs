using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_BR_Process_Event : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_BR_Process_Event_ProcessEventId { get; set; }
        public string Spartan_BR_Process_Event_Description { get; set; }

    }
}
