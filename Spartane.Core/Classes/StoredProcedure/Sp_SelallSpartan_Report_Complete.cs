using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Report_Complete : BaseEntity
    {
        public int ReportId { get; set; }
        public DateTime? Registration_Date { get; set; }
        public string Registration_Hour { get; set; }
        public int? Registration_User { get; set; }
        public int? Object { get; set; }
        public string Report_Name { get; set; }
        public int? Presentation_Type { get; set; }
        public string Presentation_Type_Description { get; set; }
        public int? Presentation_View { get; set; }
        public string Presentation_View_Description { get; set; }
        public short? Status { get; set; }
        public string Status_Description { get; set; }
        public string Query { get; set; }
        public string Filters { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
        public bool TotalColumns { get; set; }
        public bool TotalRows { get; set; }

    }
}
