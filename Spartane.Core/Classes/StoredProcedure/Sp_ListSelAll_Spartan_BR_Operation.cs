using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_BR_Operation : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_BR_Operation_OperationId { get; set; }
        public string Spartan_BR_Operation_Description { get; set; }

    }
}
