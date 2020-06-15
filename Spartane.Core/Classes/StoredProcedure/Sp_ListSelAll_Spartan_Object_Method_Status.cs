using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Object_Method_Status : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_Object_Method_Status_Object_Method_Status_Id { get; set; }
        public string Spartan_Object_Method_Status_Description { get; set; }

    }
}
