using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Attribute_Type : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Attribute_Type_Attribute_Type_Id { get; set; }
        public string Spartan_Attribute_Type_Description { get; set; }

    }
}
