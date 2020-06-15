using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Report_Order_Type : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Report_Order_Type_OrderTypeId { get; set; }
        public string Spartan_Report_Order_Type_Description { get; set; }
        public string Spartan_Report_Order_Type_Order_By { get; set; }

    }
}
