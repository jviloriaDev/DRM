using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Report_Format : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Report_Format_FormatId { get; set; }
        public string Spartan_Report_Format_Description { get; set; }
        public string Spartan_Report_Format_Format_Mask { get; set; }

    }
}
