using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Object_Characteristic : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_Object_Characteristic_Object_Characteristc_Id { get; set; }
        public string Spartan_Object_Characteristic_Description { get; set; }
        public int? Spartan_Object_Characteristic_Attribute_Type { get; set; }
        public string Spartan_Object_Characteristic_Attribute_Type_Description { get; set; }

    }
}
