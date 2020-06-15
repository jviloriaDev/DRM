using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_User_Alert_Type : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_User_Alert_Type_User_Alert_Type_Id { get; set; }
        public string Spartan_User_Alert_Type_Description { get; set; }
        public int? Spartan_User_Alert_Type_Image { get; set; }
        public string Spartan_User_Alert_Type_Image_Description { get; set; }

    }
}
