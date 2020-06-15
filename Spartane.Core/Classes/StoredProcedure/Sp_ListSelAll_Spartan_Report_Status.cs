using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Report_Status : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_Report_Status_StatusId { get; set; }
        public string Spartan_Report_Status_Description { get; set; }

    }
}
