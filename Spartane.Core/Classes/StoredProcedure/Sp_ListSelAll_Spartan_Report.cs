using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Report : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Report_ReportId { get; set; }
        public DateTime? Spartan_Report_Registration_Date { get; set; }
        public string Spartan_Report_Registration_Hour { get; set; }
        public int? Spartan_Report_Registration_User { get; set; }
        public int? Spartan_Report_Object { get; set; }
        public string Spartan_Report_Report_Name { get; set; }
        public int? Spartan_Report_Presentation_Type { get; set; }
        public string Spartan_Report_Presentation_Type_Description { get; set; }
        public int? Spartan_Report_Presentation_View { get; set; }
        public string Spartan_Report_Presentation_View_Description { get; set; }
        public short? Spartan_Report_Status { get; set; }
        public string Spartan_Report_Status_Description { get; set; }
        public string Spartan_Report_Query { get; set; }
        public string Spartan_Report_Filters { get; set; }
        public string Spartan_Report_Header { get; set; }
        public string Spartan_Report_Footer { get; set; }
        public string Spartan_Report_Object_Name { get; set; }
        public string Spartan_Report_Registration_User_Name { get; set; }
        public bool Spartan_Report_TotalColumns { get; set; }
        public bool Spartan_Report_TotalRows { get; set; }

    }
}
