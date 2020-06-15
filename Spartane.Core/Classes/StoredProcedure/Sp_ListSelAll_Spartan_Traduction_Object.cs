using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Traduction_Object : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Traduction_Object_IdObject { get; set; }
        public string Spartan_Traduction_Object_Object_Description { get; set; }
        public int? Spartan_Traduction_Object_Object_Type { get; set; }
        public string Spartan_Traduction_Object_Object_Type_Object_Type_Description { get; set; }

    }
}
