using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Report_Advance_Filter : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Report_Advance_Filter_Clave { get; set; }
        public int? Spartan_Report_Advance_Filter_Report { get; set; }
        public string Spartan_Report_Advance_Filter_Report_Report_Name { get; set; }
        public int? Spartan_Report_Advance_Filter_AttributeId { get; set; }
        public string Spartan_Report_Advance_Filter_AttributeId_Physical_Name { get; set; }
        public string Spartan_Report_Advance_Filter_Defect_Value_From { get; set; }
        public string Spartan_Report_Advance_Filter_Defect_Value_To { get; set; }
        public int? Spartan_Report_Advance_Filter_ObjectId { get; set; }
        public string Spartan_Report_Advance_Filter_PathField { get; set; }
        public string Spartan_Report_Advance_Filter_CampoQuery { get; set; }
        public bool Spartan_Report_Advance_Filter_Visible { get; set; }

    }
}
