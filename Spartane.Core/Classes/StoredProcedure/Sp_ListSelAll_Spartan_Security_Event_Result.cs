using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Security_Event_Result : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_Security_Event_Result_Security_Event_Result_Id { get; set; }
        public string Spartan_Security_Event_Result_Description { get; set; }

    }
}
