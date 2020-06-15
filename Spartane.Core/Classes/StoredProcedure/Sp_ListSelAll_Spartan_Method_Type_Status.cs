using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Method_Type_Status : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_Method_Type_Status_Method_Type_Status_Id { get; set; }
        public string Spartan_Method_Type_Status_Description { get; set; }

    }
}
