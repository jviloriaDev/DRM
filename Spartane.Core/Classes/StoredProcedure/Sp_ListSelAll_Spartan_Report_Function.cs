using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Report_Function : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Report_Function_FunctionId { get; set; }
        public string Spartan_Report_Function_Description { get; set; }

    }
}
