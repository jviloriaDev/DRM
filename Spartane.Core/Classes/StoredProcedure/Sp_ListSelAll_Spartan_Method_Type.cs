using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Method_Type : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_Method_Type_Method_Type_Id { get; set; }
        public string Spartan_Method_Type_Description { get; set; }
        public short? Spartan_Method_Type_Clasification { get; set; }
        public string Spartan_Method_Type_Clasification_Description { get; set; }
        public int? Spartan_Method_Type_Image { get; set; }
        public string Spartan_Method_Type_Image_Description { get; set; }
        public short? Spartan_Method_Type_Status { get; set; }
        public string Spartan_Method_Type_Status_Description { get; set; }

    }
}
