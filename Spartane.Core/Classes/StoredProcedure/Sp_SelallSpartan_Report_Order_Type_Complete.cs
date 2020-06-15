using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Report_Order_Type_Complete : BaseEntity
    {
        public int OrderTypeId { get; set; }
        public string Description { get; set; }
        public string Order_By { get; set; }

    }
}
