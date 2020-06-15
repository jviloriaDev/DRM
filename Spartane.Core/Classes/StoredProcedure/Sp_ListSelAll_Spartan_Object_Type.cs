using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Object_Type : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_Object_Type_Object_Type_Id { get; set; }
        public string Spartan_Object_Type_Description { get; set; }

    }
}
