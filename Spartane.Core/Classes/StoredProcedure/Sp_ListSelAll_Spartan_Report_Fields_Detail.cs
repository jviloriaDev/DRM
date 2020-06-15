using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Report_Fields_Detail : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Report_Fields_Detail_DesignDetailId { get; set; }
        public int Spartan_Report_Fields_Detail_Report { get; set; }
        public string Spartan_Report_Fields_Detail_PathField { get; set; }
        public string Spartan_Report_Fields_Detail_Physical_Name { get; set; }
        public string Spartan_Report_Fields_Detail_Title { get; set; }
        public int? Spartan_Report_Fields_Detail_Function { get; set; }
        public string Spartan_Report_Fields_Detail_Function_Description { get; set; }
        public int? Spartan_Report_Fields_Detail_Format { get; set; }
        public string Spartan_Report_Fields_Detail_Format_Description { get; set; }
        public int? Spartan_Report_Fields_Detail_Order_Type { get; set; }
        public string Spartan_Report_Fields_Detail_Order_Type_Description { get; set; }
        public short? Spartan_Report_Fields_Detail_Field_Type { get; set; }
        public string Spartan_Report_Fields_Detail_Field_Type_Description { get; set; }
        public int? Spartan_Report_Fields_Detail_Order_Number { get; set; }
        public int? Spartan_Report_Fields_Detail_AttributeId { get; set; }
        public string Spartan_Report_Fields_Detail_AttributeId_Physical_Name { get; set; }
        public bool Spartan_Report_Fields_Detail_Subtotal { get; set; }

    }
}
