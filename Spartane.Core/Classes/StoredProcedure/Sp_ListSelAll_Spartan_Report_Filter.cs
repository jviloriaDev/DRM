using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Report_Filter : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Report_Filter_ReportFilterId { get; set; }
        public int Spartan_Report_Filter_Report { get; set; }
        public int? Spartan_Report_Filter_Field { get; set; }
        public string Spartan_Report_Filter_Field_Logical_Name { get; set; }
        public bool? Spartan_Report_Filter_QuickFilter { get; set; }
        public bool? Spartan_Report_Filter_AdvanceFilter { get; set; }

    }
}
