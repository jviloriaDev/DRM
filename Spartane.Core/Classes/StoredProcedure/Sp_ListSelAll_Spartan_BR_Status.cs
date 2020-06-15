using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_BR_Status : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_BR_Status_StatusId { get; set; }
        public string Spartan_BR_Status_Description { get; set; }

    }
}
