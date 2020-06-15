using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Report_Filter_Complete : BaseEntity
    {
        public int ReportFilterId { get; set; }
        public int Report { get; set; }
        public int? Field { get; set; }
        public string Field_Logical_Name { get; set; }
        public bool? QuickFilter { get; set; }
        public bool? AdvanceFilter { get; set; }

    }
}
