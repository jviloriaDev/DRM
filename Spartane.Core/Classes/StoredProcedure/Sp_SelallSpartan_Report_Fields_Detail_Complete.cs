using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Report_Fields_Detail_Complete : BaseEntity
    {
        public int DesignDetailId { get; set; }
        public int Report { get; set; }
        public string PathField { get; set; }
        public string Physical_Name { get; set; }
        public string Title { get; set; }
        public int? Function { get; set; }
        public string Function_Description { get; set; }
        public int? Format { get; set; }
        public string Format_Description { get; set; }
        public int? Order_Type { get; set; }
        public string Order_Type_Description { get; set; }
        public short? Field_Type { get; set; }
        public string Field_Type_Description { get; set; }
        public int? Order_Number { get; set; }
        public int? AttributeId { get; set; }
        public string AttributeId_Physical_Name { get; set; }
        public bool Subtotal { get; set; }

    }
}
