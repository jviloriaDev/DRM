using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Attribute_Control_Type : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_Attribute_Control_Type_ControlTypeId { get; set; }
        public string Spartan_Attribute_Control_Type_Description { get; set; }

    }
}
