using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Order_Type : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_Order_Type_Order_Type_Id { get; set; }
        public string Spartan_Order_Type_Description { get; set; }

    }
}
