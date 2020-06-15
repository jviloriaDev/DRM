using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Report_Presentation_View : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Report_Presentation_View_PresentationViewId { get; set; }
        public string Spartan_Report_Presentation_View_Description { get; set; }
        public int? Spartan_Report_Presentation_View_Presentation_Type { get; set; }
        public string Spartan_Report_Presentation_View_Presentation_Type_Description { get; set; }

    }
}
